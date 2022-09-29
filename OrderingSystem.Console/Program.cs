using System.Diagnostics;
using OrderingSystem.Domain;
using OrderingSystem.Domain.Enums;
using OrderingSystem.Json;
using OrderingSystem.Services;

var billJson = new BillJsonLogic();
PdfService.CreatePdfBill(billJson.Bills.Find(x => x.BillNumber == 1));

