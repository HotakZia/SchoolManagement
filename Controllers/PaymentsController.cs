using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models.db;


namespace SchoolManagement.Controllers
{
  
    public class PaymentsController : BaseController
    {
        //private readonly School_dbContext db;

        //public PaymentsController(School_dbContext context)
        //{
        //    db = context;
        //}


        public ActionResult ExportToExcel()
        {
            //    List<string> dataList = new List<string>
            //{
            //    "Data 1",
            //    "Data 2",
            //    "Data 3"
            //};
            var list = db.Payments.ToList();


            // Create a new Excel workbook
            //    using (var workbook = new XLWorkbook())
            //    {
            //        // Add a worksheet
            //        var worksheet = workbook.Worksheets.Add("Sheet 1");

            //        // Add a logo to the header
            //        var logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "template", "assets", "img", "logo.png");
            //        if (System.IO.File.Exists(logoPath))
            //        {
            //            var logo = worksheet.AddPicture(logoPath)
            //                                .MoveTo(worksheet.Cell(1, 1), 0, 0)
            //                                .Scale(0.1); // Adjust scale
            //         logo.Height=100;
            //        logo.Width = 100;
            //        // Adjust the size of the cell containing the logo
            //        worksheet.Cell(1, 1).WorksheetRow().Height = 100;
            //        worksheet.Column(1).Width = 100;
            //    }

            //    // Set header title (merged cells, centered)
            //    worksheet.Cell(1, 2).Value = "Sales Report"; // Header title
            //    worksheet.Range("B1:F1").Merge();
            //    worksheet.Cell(1, 2).Style.Font.SetBold().Font.SetFontSize(16).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            //    //// Add address and contact information
            //    //worksheet.Cell(2, 2).Value = "Contact: +123456789 | Address: 123 Main St, City";
            //    //worksheet.Range("B2:F2").Merge();
            //    //worksheet.Cell(2, 2).Style.Font.SetFontSize(12).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            //    //// Add our services
            //    //worksheet.Cell(3, 2).Value = "Our Services: Service A, Service B, Service C";
            //    //worksheet.Range("B3:F3").Merge();
            //    //worksheet.Cell(3, 2).Style.Font.SetFontSize(12).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            //    //// Add column headers
            //    worksheet.Cell(2, 1).Value = "No";
            //        worksheet.Cell(2, 2).Value = "Product Name";
            //        worksheet.Cell(2, 3).Value = "Quantity";
            //        worksheet.Cell(2, 4).Value = "Price";
            //        worksheet.Cell(2, 5).Value = "Total";
            //        worksheet.Range(2,1,2,5).Style.Font.SetBold().Fill.SetBackgroundColor(XLColor.LightGray);

            //        // Sample data (can replace with dynamic data)
            ////        var products = new[]
            ////        {
            ////    new { ProductName = "Product A", Quantity = 5, Price = 10.0 },
            ////    new { ProductName = "Product B", Quantity = 3, Price = 20.0 },
            ////    new { ProductName = "Product C", Quantity = 8, Price = 7.5 },
            ////};

            //        // Populate data into the rows
            //        int row = 3;
            //        foreach (var product in list)
            //        {
            //            worksheet.Cell(row, 1).Value = row - 2; // Row number
            //            worksheet.Cell(row, 2).Value = product.Name;
            //            worksheet.Cell(row, 3).Value = product.Name;
            //            worksheet.Cell(row, 4).Value = product.Name;
            //        worksheet.Cell(row, 5).Value = product.Name;

            //        // Apply style to each row
            //        //worksheet.Row(row).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            //        worksheet.Range(row,1,row,5).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            //        //worksheet.Row(row).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            //        worksheet.Range(row,1,row,5).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            //        //worksheet.Cell(row,2).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            //        worksheet.Range(row, 1,row,5).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            //        //worksheet.Range(row,1, row ,2).Style.Fill.BackgroundColor = XLColor.Red;
            //        row++;
            //        }

            //    //Auto - size columns
            //     worksheet.Columns().AdjustToContents();

            //    // Set the response headers to prompt for download
            //    var stream = new MemoryStream();
            //        workbook.SaveAs(stream);
            //        stream.Position = 0;

            //        // Return the file to the user
            //        return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SalesReport.xlsx");
            //    }
            var systemInfo = db.TableCompanies.FirstOrDefault();
            // Create a new Excel workbook and worksheet
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Payments");

                // Add a logo to the header
                var logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "template", "assets", "img", "logo.png");
                //if (File.Exists(logoPath))
                //{ }
                    var logo = worksheet.AddPicture(logoPath)
                                        .MoveTo(worksheet.Cell(1, 1), 0, 0)
                                        .Scale(0.1); // Adjust scale
                    logo.Height = 100;
                    logo.Width = 100;
                    // Adjust the size of the cell containing the logo
                    worksheet.Cell(1, 1).WorksheetRow().Height = 100;
                    worksheet.Column(1).Width = 100;


                // Set header title (merged cells, centered)
                worksheet.Cell(1, 2).Value = systemInfo.Name; //systemInfo.Name;
                worksheet.Range("B1:F1").Merge();
                worksheet.Cell(1, 2).Style.Font.SetBold().Font.SetFontSize(24).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center).Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                // Add contact information
                worksheet.Cell(2, 2).Value = systemInfo.PhoneNumber+"/"+systemInfo.Email;
                worksheet.Range("B2:F2").Merge();
                worksheet.Cell(2, 2).Style.Font.SetFontSize(14).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                // Add additional details
                worksheet.Cell(3, 2).Value = systemInfo.Location;
                worksheet.Range("B3:F3").Merge();
                worksheet.Cell(3, 2).Style.Font.SetFontSize(12).Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                // Add column headers
                worksheet.Cell(4, 1).Value = "Number";
                worksheet.Cell(4, 2).Value = "Payment Name";
                worksheet.Cell(4, 3).Value = "Created";
                worksheet.Cell(4, 4).Value = "Amount";
                worksheet.Cell(4, 5).Value = "Type";
                worksheet.Cell(4, 6).Value = "Comment";
             
                worksheet.Range(4, 1, 4, 6).Style.Font.SetBold().Fill.SetBackgroundColor(XLColor.LightGray);
                // Populate data into the rows
                int row = 5;
                foreach (var product in list)
                {
                    worksheet.Cell(row, 1).Value = product.Number; // Row number
                    worksheet.Cell(row, 2).Value = product.Name;
                    worksheet.Cell(row, 3).Value = product.CreatedDate.Value.ToShortDateString();
                    worksheet.Cell(row, 4).Value = product.Amount;
                    worksheet.Cell(row, 5).Value = product.Type;
                    worksheet.Cell(row, 6).Value = product.Comment;
                    //worksheet.Cell(row, 5).FormulaA1 = $"C{row}*D{row}"; // Total calculation

                    // Apply style to each row
                    worksheet.Row(row).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    worksheet.Range(row, 1, row, 6).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Range(row, 1, row, 6).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Columns(row,6).Width = 500;
                    row++;
                }
             
                // After populating the data and setting up the worksheet

                // Add footer at the end of the worksheet
                worksheet.PageSetup.Footer.Left.AddText("Footer Text Left");
                worksheet.PageSetup.Footer.Center.AddText("Footer Text Center");
                worksheet.PageSetup.Footer.Right.AddText("Footer Text Right");

                // You can customize the footer further by adding page number or date
                worksheet.PageSetup.Footer.Center.AddText("Page &P of &N"); // Page number
                worksheet.PageSetup.Footer.Right.AddText("&D"); // Date


                // After populating the data and setting up the worksheet

                // Auto-size columns to fit content
                worksheet.Columns().AdjustToContents();


              

                // Set the response headers to prompt for download
                var stream = new MemoryStream();
                workbook.SaveAs(stream);
                stream.Position = 0;

                // Return the file to the user
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PaymentsReport.xlsx");
            }


        }
        // GET: Payments
        [Route("allpayments")]
        public async Task<IActionResult> Index()
        {
            var list = await db.Payments.ToListAsync();
            return View(list);
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await db.Payments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Amount,Id,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Name,Type")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var duplicate = db.Payments.Where(x => x.Name ==payment.Name).FirstOrDefault();
                    if (duplicate!=null)
                    {
                        showMessageString = new
                        {
                            status = "duplicate",
                            message = payment.Name+" "+" is dupplicate name!"
                            
                        };
                        return Json(showMessageString);
                    }
                    payment.Id = Guid.NewGuid();
                    payment.CreatedDate = DateTime.Now;
                    payment.Status = true;

                    db.Add(payment);
                    await db.SaveChangesAsync();
                    showMessageString = new
                    {
                        status = "true",
                        message = "New payment has been saved.",
                        Id=payment.Id,
                    };
                    return Json(showMessageString);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    showMessageString = new
                    {
                        status = "false",
                        message = ex.Message
                    };
                    return Json(showMessageString);
                }
         
            }
            return View(payment);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await db.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Amount,Id,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Name,Type")] Payment payment)
        {
            if (id != payment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var duplicate = db.Payments.Where(x => x.Name == payment.Name).FirstOrDefault();
                    if (duplicate != null)
                    {
                        showMessageString = new
                        {
                            status = "duplicate",
                            message = payment.Name + " " + " is dupplicate name!"

                        };
                        return Json(showMessageString);
                    }
              
                    payment.ModifiedDate = DateTime.Now;

                    db.Update(payment);
                    await db.SaveChangesAsync();
                    showMessageString = new
                    {
                        status = "true",
                        message = payment.Name+" payment has been updated."
                    };
                    return Json(showMessageString);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    showMessageString = new
                    {
                        status = "false",
                        message = ex.Message
                    };
                    return Json(showMessageString);
                }

            }
            return View(payment);
          
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await db.Payments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var payment = await db.Payments.FindAsync(id);
            db.Payments.Remove(payment);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(Guid id)
        {
            return db.Payments.Any(e => e.Id == id);
        }
    }
}
