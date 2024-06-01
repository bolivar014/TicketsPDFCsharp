using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

class Program
{
    static void Main()
    {
        // Crear una instancia de la clase Random
        Random random = new Random();

        // Generar un número entero aleatorio entre 0 y 100
        int randomNumber = random.Next(0, 101);

        // Ruta donde se guardará el archivo PDF
        string path = $"C:/Users/JUAN-/OneDrive/Documentos/Varios/tickets_prueba/ticket_{randomNumber}.pdf";

        Console.WriteLine("Iniciando creación de ticket en: " + path);

        // Crear un nuevo documento PDF
        Document document = new Document(PageSize.A4, 50, 50, 25, 25);

        // Crear un escritor de PDF para el documento
        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));

        // Abrir el documento para escribir
        document.Open();

        // Añadir contenido al documento
        // Encabezado del ticket
        Font titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
        Paragraph title = new Paragraph("Ticket de Compra", titleFont);
        title.Alignment = Element.ALIGN_CENTER;
        document.Add(title);

        // Espacio
        document.Add(new Paragraph("\n"));

        // Información del ticket
        Font contentFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
        document.Add(new Paragraph("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"), contentFont));
        document.Add(new Paragraph("Hora: " + DateTime.Now.ToString("HH:mm:ss"), contentFont));
        document.Add(new Paragraph("Número de Ticket: 12345", contentFont));
        document.Add(new Paragraph("Nombre del Cliente: Pepito Pérez", contentFont));

        // Espacio
        document.Add(new Paragraph("\n"));

        // Detalles del producto
        PdfPTable table = new PdfPTable(3);
        table.WidthPercentage = 100;
        table.SetWidths(new float[] { 40f, 30f, 30f });

        table.AddCell(new PdfPCell(new Phrase("Producto", contentFont)));
        table.AddCell(new PdfPCell(new Phrase("Cantidad", contentFont)));
        table.AddCell(new PdfPCell(new Phrase("Precio", contentFont)));

        table.AddCell(new PdfPCell(new Phrase("Producto A", contentFont)));
        table.AddCell(new PdfPCell(new Phrase("2", contentFont)));
        table.AddCell(new PdfPCell(new Phrase("$20.00", contentFont)));

        table.AddCell(new PdfPCell(new Phrase("Producto B", contentFont)));
        table.AddCell(new PdfPCell(new Phrase("1", contentFont)));
        table.AddCell(new PdfPCell(new Phrase("$15.00", contentFont)));

        document.Add(table);

        // Espacio
        document.Add(new Paragraph("\n"));

        // Total
        document.Add(new Paragraph("Total: $55.00", contentFont));

        // Cerrar el documento
        document.Close();

        Console.WriteLine("El ticket se ha creado exitosamente en: " + path);
    }
}
