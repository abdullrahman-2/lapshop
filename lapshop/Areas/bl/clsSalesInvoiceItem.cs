using lapshop.Models;

namespace lapshop.Areas.bl
{
    public interface ISalesInvoiceItem {

        public List<TbSalesInvoiceItem> getInvoiceById(int id);

        public bool save(IList<TbSalesInvoiceItem>  item, int slaesInoiceID, bool isnew);

    }
    public class clsSalesInvoiceItem : ISalesInvoiceItem
    {
        

            LapShopContext context;
            public clsSalesInvoiceItem(LapShopContext ctx)
            {

                context = ctx;
            }

        public clsSalesInvoiceItem()
        {

            
        }

        public List<TbSalesInvoiceItem> getInvoiceById(int id)
            {

                try
                {

               
                    var item = context.TbSalesInvoiceItems.Where(a => a.InvoiceId == id ).ToList();
                if (item == null)
                {
                    return new List<TbSalesInvoiceItem>();
                    
                
                }
                else
                    return item;

            }

                catch (Exception ex) 
                {
                throw new Exception();
                }

            }



        public bool save(IList<TbSalesInvoiceItem> item, int slaesInoiceID, bool isnew)
        {

            List<TbSalesInvoiceItem> dbInviceItem = getInvoiceById(item[0].InvoiceId);

            foreach (var interFaceItem in item) { 
            
            var dbObject = dbInviceItem.Where(a=>a.InvoiceItemId == interFaceItem.InvoiceItemId).FirstOrDefault();
                if (dbObject != null)
                    context.Entry(dbObject).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                else
                {
                    interFaceItem.InvoiceId = slaesInoiceID;
                    context.TbSalesInvoiceItems.Add(interFaceItem);
                }
            }
            foreach (var Dbitem in dbInviceItem) {
                var OBinterFaceItem = item.Where(a => a.InvoiceItemId == Dbitem.InvoiceItemId).FirstOrDefault();
                if(OBinterFaceItem != null)
                    context.TbSalesInvoiceItems.Remove(OBinterFaceItem);

            }

        context.SaveChanges();
                    return true;
                






            }

            //public bool delete(int id)
            //{

            //    try
            //    {

            //        var item = getInvoiceById(id);
                   
            //        context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //        context.SaveChanges();
            //        return true;


            //    }
            //    catch
            //    {
            //        return false;
            //    }
            //}




        }
    }

