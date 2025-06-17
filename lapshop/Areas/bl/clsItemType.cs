using lapshop.Models;

namespace lapshop.Areas.bl
{

    public interface Iitemtype
    {
        List<TbItemType> getAll();
        TbItemType getById(int id);
        bool save(TbItemType ItemType);
        bool delete(int id);

    }
    public class  clsItemType : Iitemtype
    {
        LapShopContext context;
        public clsItemType(LapShopContext ctx)
        {

            context = ctx;
        }

        public List<TbItemType> getAll() {
            try
            {

                

                var lstItemType = context.TbItemTypes.Where(e=>e.CurrentState == 1).OrderBy(a => a.ItemTypeId).ToList();

                return lstItemType;
            }
            catch { 
            
            return new List<TbItemType> ();
            }
          
        }


        public TbItemType getById(int id) {

            try {
                

                    var ItemType = context.TbItemTypes.FirstOrDefault(a => a.ItemTypeId == id && a.CurrentState==1);

                return ItemType;

            }

            catch { 
            return new TbItemType ();
            }
        
        }

        public bool save(TbItemType ItemType) {

            try
            {
                

               
                if (ItemType.ItemTypeId == 0)
                {
                    ItemType.CreatedBy = "ali";
                    ItemType.CreatedDate = DateTime.Now;
                    context.Add(ItemType);
                }
                else
                {
                    context.Entry(ItemType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

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
                
                var ItemType = getById(id);
                ItemType.CurrentState = 0;
                context.SaveChanges();
                return true;


            }
            catch { 
            return false;
            }
        }

    

        //public async Task<string> UpldadFile(List<IFormFile> files)
        //{

        //    foreach (var file in files)
        //    {

        //        if (file.Length > 0)
        //        {

        //            string imageName = Guid.NewGuid().ToString() + ".jpg";

        //            var FilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", imageName);

        //            using (var stream = System.IO.File.Create(FilePath))

        //            {
        //                await file.CopyToAsync(stream);
        //                return imageName;
        //            }

        //        }



        //    }


        //    return "";
        //}



    }
}
