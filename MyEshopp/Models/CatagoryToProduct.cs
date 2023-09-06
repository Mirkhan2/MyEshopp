namespace MyEshopp.Models
{
	public class CatagoryToProduct
	{
        public int CatagoryId { get; set; }
        public int ProductId { get; set; }
        // Navigation Property rabete 1 be 1
        public Catagory Catagory{ get; set; }
        public Product Product { get; set; }
        //agar rabete chand ba chand bashe az lis bayad estefada konim
    }
}
