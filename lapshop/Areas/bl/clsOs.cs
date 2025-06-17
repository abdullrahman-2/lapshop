using lapshop.Models;

namespace lapshop.Areas.bl
{
    public interface Ios
    {
        List<TbO> getAll();
        TbO getById(int id);
        bool save(TbO OS);
        bool delete(int id);

    }
    public class clsOs : Ios
    {
        LapShopContext context;
        public clsOs(LapShopContext ctx)
        {

            context = ctx;
        }
        public List<TbO> getAll() {
            try
            {

                

                var lstO = context.TbOs.Where(e => e.CurrentState == 1).OrderBy(a => a.OsId).ToList();

                return lstO;
            }
            catch { 
            
            return new List<TbO>();
            }
          
        }


        public TbO getById(int id) {

            try {
                

                    var OS = context.TbOs.FirstOrDefault(a => a.OsId == id&& a.CurrentState==1);

                return OS;
              
            }

            catch { 
            return new TbO ();
            }
        
        }

        public bool save(TbO OS) {

            try
            {
                

               
                if (OS.OsId == 0)
                {
                    OS.CreatedBy = "ali";
                    OS.CreatedDate = DateTime.Now;
                    context.Add(OS);
                }
                else
                {
                    context.Entry(OS).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

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
                
                var OS = getById(id);
                OS.CurrentState = 0;
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
