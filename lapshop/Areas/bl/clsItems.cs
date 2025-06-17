using lapshop.Helpers;
using lapshop.Models;

namespace lapshop.Areas.bl
{
    public interface ITems {
        public List<TbItem> getAll();
        public List<VwItem> getAllData(int? id);
        public List<VwItem> getRlatedItems(int id);

        public TbItem getById(int id);

     public VwItem getVitemById(int id);


        public bool save(TbItem item);

        public bool delete(int id);
    }

    public class clsItems : ITems
    {
        LapShopContext context;
        public clsItems(LapShopContext ctx) {
        
        context = ctx;
        } 

        public List<TbItem> getAll()
        {
            
            try
            {

                
                var lstCategories = context.TbItems.ToList();

                return lstCategories;
            }
            catch
            {

                return new List<TbItem>();
            }

        }


        public List<VwItem> getAllData(int? id)
        {
            try
            {
           
                  var item=  context.VwItems.Where(e => (e.CategoryId == id)|| id==0 || id == null && e.CurrentState ==1 ).ToList();
                    return item.ToList();
         
            }
            catch
            {

                return new List<VwItem>();
            }

        }

       


              public List<VwItem> getRlatedItems(int id)
        {

            try
            {

                var item2 = getById(id);
                var item = context.VwItems.Where(a => item2.SalesPrice>a.SalesPrice+50  && a.CurrentState == 1).Take(5).ToList();

                return item;


            }

            catch
            {
                return new List<VwItem>();
            }

        }

        public TbItem getById(int id)
        {

            try
            {
                

                var item = context.TbItems.FirstOrDefault(a => a.ItemId == id && a.CurrentState==1);

                return item;


            }

            catch
            {
                return new TbItem();
            }

        }

        public VwItem getVitemById(int id)
        {

            try
            {


                var item = context.VwItems.FirstOrDefault(a => a.ItemId == id && a.CurrentState == 1);

                return item;


            }

            catch
            {
                return new VwItem();
            }

        }

        public bool save(TbItem item)
        {
            item.CurrentState = 1;

            try
            {
                


                if (item.ItemId == 0)
                {
                    item.CreatedBy = "ali";
                    item.CreatedDate = DateTime.Now;
                    context.Add(item);
                }
                else
                {
                    context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                }

                context.SaveChanges();

                return true;
            }




            catch
            {

                return false;

            }


        }

        public bool delete(int id)
        {

            try
            {
                
                var item = getById(id);
                item.CurrentState = 0;
                context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return true;


            }
            catch
            {
                return false;
            }
        }

       


    }
}
