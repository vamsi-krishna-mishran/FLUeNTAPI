namespace WEBAPIFLUENT.Models
{
    public class AssembledBoardDetails
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        public string Remark { get; set; }

        public int IId { get; set; }
        public Identity Identity { get; set; }
    }
}
