namespace project_management_system_backend.Models
{
    public class ReqirmentReqDoucment:BaseModel
    {
        public int Id { get; set; }
       
        public Requirment Reqirment { get; set; }
        public ReqDocument ReqDoucument { get; set; }


    }
}
