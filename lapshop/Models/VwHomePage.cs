namespace lapshop.Models
{
    public class VwHomePage
    {
        public VwHomePage() {

            Categories = new List<TbCategory>();
            AllItems = new List<VwItem>();  
            RecomendeItems = new List<VwItem>();
          
        }

        public TbSetting TbSetting { get; set; }

        public List<TbCategory> Categories;

        public List<VwItem> AllItems;

        public List<VwItem> RecomendeItems;
        public HomePageSetting HomePageSetting { get; set; }

    }
}
