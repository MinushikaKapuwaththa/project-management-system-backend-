namespace project_management_system_backend.Controllers
{
    public class HttpPostedFileBase
    {
        public int ContentLength { get; internal set; }
        public IDisposable InputStream { get; internal set; }
    }
}