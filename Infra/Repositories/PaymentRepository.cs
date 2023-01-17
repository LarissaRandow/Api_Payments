using Core.Entities;
using Core.Interfaces.IRepository;
using ClosedXML.Excel;

namespace Infra.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public async Task<IEnumerable<IEnumerable<Payment>>> GetUserPayment(string aGrid, string bGrid, string cGrid)
        {
            var paymentList = new List<List<Payment>>();

            var aGridList = new List<Payment>();
            var bGridList = new List<Payment>();
            var cGridList = new List<Payment>();

            var xls = new XLWorkbook($"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}\\Api_Payments\\Infra\\Data\\Excel.xlsx");
            var sheet = xls.Worksheets.First(w => w.Name == "Sheet1");
            var rows = sheet.Rows().Count();

            for (int i = 2; i <= rows; i++)
            {
                string type = sheet.Cell($"B{i}").Value.ToString();

                if(type == aGrid)
                {
                    aGridList.Add(new Payment 
                    { 
                        Id = Int32.Parse(sheet.Cell($"A{i}").Value.ToString()), 
                        Type = type, 
                        Value = Decimal.Parse(sheet.Cell($"C{i}").Value.ToString())
                    });
                }
                else if (type == bGrid)
                {
                    bGridList.Add(new Payment
                    {
                        Id = Int32.Parse(sheet.Cell($"A{i}").Value.ToString()),
                        Type = type,
                        Value = Decimal.Parse(sheet.Cell($"C{i}").Value.ToString())
                    });
                }
                else if (type == cGrid)
                {
                    cGridList.Add(new Payment
                    {
                        Id = Int32.Parse(sheet.Cell($"A{i}").Value.ToString()),
                        Type = type,
                        Value = Decimal.Parse(sheet.Cell($"C{i}").Value.ToString())
                    });
                }
            }

            paymentList.Add(aGridList);
            paymentList.Add(bGridList);
            paymentList.Add(cGridList);

            return await Task.FromResult(paymentList);
        }
    }
}
