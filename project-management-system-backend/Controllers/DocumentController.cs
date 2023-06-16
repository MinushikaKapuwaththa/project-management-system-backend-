using Microsoft.AspNetCore.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using project_management_system_backend.Models;
using project_management_system_backend.Repostories;


namespace project_management_system_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IDocumentUploaderService _documentUploaderService;
        private readonly IMapper _mapper;
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public DocumentsController(IDocumentRepository documentRepository, IDocumentUploaderService documentUploaderService, IMapper mapper,
            FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _documentRepository = documentRepository;
            _documentUploaderService = documentUploaderService;
            _mapper = mapper;
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider;
        }


        [HttpGet]
        public async Task<ActionResult<List<DocumentDetailsDto>>> GetDocumentDetails()
        {
            try
            {
                var documents = await _documentRepository.GetDocumentListAsync();
                return Ok(documents);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateDocumentAsync([FromForm] DocumentUploadDto document)
        {
            //Move document to local repository
            var result = await _documentUploaderService.UploadDocument(document);

            if (result != null)
            {
                //Save document meta data in the table
                await _documentRepository.SaveDocumentMetaData(result);
                return Ok();
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("{documentId}")]
        public async Task<ActionResult> DownloadDocumentAsync(int documentId)
        {
            try
            {
                var document = await _documentRepository.GetDocumentByIdAsync(documentId);

                if (document == null)
                {
                    return NotFound();
                }

                var byteArray = await _documentUploaderService.DownloadDocument(document.FilePath, document.ActualFileName);

                if (byteArray == null)
                {
                    return NotFound("Unable to download document");
                }

                if (!_fileExtensionContentTypeProvider.TryGetContentType(document.ActualFileName, out var contentType))
                {
                    contentType = "application/octet-stream";
                }

                return File(byteArray, contentType, document.ActualFileName);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpDelete("{documentId}")]
        public async Task<IActionResult> DeleteDocument(int documentId)
        {
            var documentToDelete = await _documentRepository.GetDocumentByIdAsync(documentId);

            if (documentToDelete == null)
            {
                return NotFound();
            }

            await _documentRepository.DeleteDocumentAsync(documentToDelete);

            _documentUploaderService.RemoveDocumentFromRepository(documentToDelete.FilePath, documentToDelete.ActualFileName);

            return NoContent();
        }
    }
}
