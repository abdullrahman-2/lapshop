using lapshop.Models;

namespace lapshop.Areas.bl
{
    public interface ISalesInvoice {
        public List<VwSalesInvoice> getAll();

        public TbSalesInvoice getById(int id);

        public bool save(TbSalesInvoice item, List<TbSalesInvoiceItem> lstitems, bool isNew);

        public bool delete(int id);
    }
    public class clsSalesInvoice : ISalesInvoice
    {
        LapShopContext context;
        ISalesInvoiceItem salesInvoiceItemSarvice;
        public clsSalesInvoice(LapShopContext ctx,ISalesInvoiceItem salesInvoiceItem)
        {
            salesInvoiceItemSarvice = salesInvoiceItem;
            context = ctx;
        }


        public List<VwSalesInvoice> getAll()
        {

            try
            {



                var lstCategories = context.VwSalesInvoices.ToList();

                return lstCategories;
            }
            catch
            {

                return new List<VwSalesInvoice>();
            }

        }


        public TbSalesInvoice getById(int id)
        {

            try
            {


                var item = context.TbSalesInvoices.FirstOrDefault(a => a.InvoiceId == id && a.CurrentState == 1);

                return item;


            }

            catch
            {
                return new TbSalesInvoice();
            }

        }

        //public VwSalesInvoice getVitemById(int id)
        //{

        //    try
        //    {


        //        var item = context.VwSalesInvoices.FirstOrDefault(a => a.InvoiceId == id && a.CurrentState == 1);

        //        return item;


        //    }

        //    catch
        //    {
        //        return new VwSalesInvoice();
        //    }

        //}

        public bool save(TbSalesInvoice item ,List <TbSalesInvoiceItem> lstitems, bool isNew)
        {

            using var transaction = context.Database.BeginTransaction(); 
            try
            {
                item.CurrentState = 1;
                if (isNew)
                {
                    item.CreatedBy = "ali";
                    item.CreatedDate = DateTime.Now;
                    context.TbSalesInvoices.Add(item);
                }
                else
                {
                    item.UpdatedBy = "1";
                    item.UpdatedDate = DateTime.Now;
                    context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                }
               
                context.SaveChanges();

                salesInvoiceItemSarvice.save(lstitems,item.InvoiceId,true);
                
                transaction.Commit();

                return true;
            }


            catch(Exception ex)
            {
                transaction.Rollback();
                throw new Exception();
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

