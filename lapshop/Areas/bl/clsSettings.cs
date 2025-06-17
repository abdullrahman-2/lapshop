using lapshop.Models;

namespace lapshop.Areas.bl
{
    public interface ISetting
    {
        public List<TbSetting> getAll();

        public TbSetting getById(int id);
        public bool save(TbSetting setting);

        public bool delete(int id);
    }
   
        

        public class Clssetting : ISetting
        {
            LapShopContext context;
            public Clssetting(LapShopContext ctx)
            {

                context = ctx;
            }


            public List<TbSetting> getAll()
            {
                try
                {



                    var lstSettings = context.TbSettings.ToList();

                    return lstSettings;
                }
                catch
                {

                    return new List<TbSetting>();
                }

            }


            public TbSetting getById(int id)
            {

                try
                {

                    var setting = context.TbSettings.FirstOrDefault(a => a.SettingId == id );



                    return setting;


                }

                catch
                {
                    return new TbSetting();
                }

            }

        public bool save(TbSetting setting)
        {
            try
            {
                if (setting.SettingId == 0)
                {
                    context.Add(setting);
                }
                else
                {
                    context.Entry(setting).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    
                    var setting = getById(id);

                    if (setting == null)
                    {
                        
                        return false;
                    }


                    context.TbSettings.Remove(setting);

                
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                   
                    return false; 
                }
            }
               
            

        }
    }

