namespace FCommerce.DataAcsess.Repos.Implimentations
{
    public class BaseModel
    {
        public BaseModel()
        {
            this.IsActive = true;
        }
        public bool IsActive { get; set; }
    }
}
