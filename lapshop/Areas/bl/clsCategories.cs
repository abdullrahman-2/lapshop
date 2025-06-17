using lapshop.Helpers;
using lapshop.Models;

namespace lapshop.Areas.bl
{

    public interface iCategory {
        public List<TbCategory> getAll();
        public TbCategory getById(int id);

        public bool save(TbCategory category);

        public bool delete(int id);

    }

    public class ClsCategory : iCategory 
    {
        LapShopContext context;
        public ClsCategory(LapShopContext ctx)
        {

            context = ctx;
        }


        public List<TbCategory> getAll() {
            try
            {

                

                var lstCategories = context.TbCategories.Where(e=>e.CurrentState==1).OrderBy(a => a.CategoryId).ToList();

                return lstCategories;
            }
            catch { 
            
            return new List<TbCategory> ();
            }
          
        }


        public TbCategory getById(int id) {

            try {
                

                    var category = context.TbCategories.FirstOrDefault(a => a.CategoryId == id &&a.CurrentState==1);

                if (category.ShowInHomePage == null)
                {
                    category.ShowInHomePage = false;
                }

                return category;
               

            }

            catch { 
            return new TbCategory ();
            }
        
        }

        public bool save(TbCategory category) {

            try
            {
                

               
                if (category.CategoryId == 0)
                {
                    category.CreatedBy = "ali";
                    category.CreatedDate = DateTime.Now;
                    context.Add(category);
             


                }
                else
                {
                    context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                }

                context.SaveChanges();
                return true;
            }




            catch
            {

                return false;
            }
        
        
        }

        public bool delete(int id) {

            try
            {
                
                var category = getById(id);
                category.CurrentState = 0;
                context.SaveChanges();
                return true;


            }
            catch { 
            return false;
            }
        }

       

   



    }
}
