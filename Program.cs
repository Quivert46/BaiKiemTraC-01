using System;
using System.Collections.Generic;
using System.Linq;
public abstract class Pt
{
    private string ma;
    private string ten;
    private int namsx;
    private decimal gia;

    public string Ma
    {
        get
        {
            return ma;
        }
        set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Ma khong duoc de trong");
            }
            ma = value;
        }
    }

    public string Ten
    {
        get
        {
            return ten;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Ten khong duoc de trong");
            }
            ten = value;
        }
    }

    public int Nam
    {
        get
        {
            return namsx;
        }
        set
        {
            int namht = DateTime.Now.Year;

            if(value < 1900 || value > namht)
            {
                throw new ArgumentException("Nam san xuat phai tu 1900 den " + namht);
            }
            namsx = value;
        }
    }

    public decimal Gia
    {
        get
        {
            return gia;
        }
        set
        {
            if(value <= 0)
            {
                throw new ArgumentException("Gia phai lon hon 0");
            }
            gia = value;
        }
    }
    public Pt(string ma, string ten, int namsx, decimal gia)
    {
        Ma = string.IsNullOrWhiteSpace(ma) ? "PT000" : ma;
        Ten = ten;
        Nam = namsx;
        Gia = gia;
    }

    public abstract decimal TinhGiaLanBanh();

    public virtual string GetInfo()
    {
        return "Ma PT: " + ma + "  |  "
            + "Ten hang: " + ten + "  |  "
            + "Nam SX: " + namsx + "  |  "
            + "Gia: " + gia + "VND";
    }
}

public class Oto : Pt
{
    private int socho;
    private double dtdc;

    public int Socho
    {
        get
        {
            return socho;
        }
        set
        {
            if(value <= 0)
            {
                throw new ArgumentException("So cho phai lon hon 0");
            }
            socho = value;
        }
    }

    public double Dtdc
    {
        get
        {
            return dtdc;
        }
        set
        {
            if(value <= 0)
            {
                throw new ArgumentException("Dung tich dong co phai lon hon 0");
            }
            dtdc = value;
        }
    }

    public Oto(string ma, string ten, int namsx, decimal gia, int socho, double dtdc) : base(ma, ten, namsx, gia)
    {
        Socho = socho;
        Dtdc = dtdc;
    }

    public override decimal TinhGiaLanBanh()
    {
        if(Socho <= 9)
        {
            return Gia + Gia * 0.12m + Gia * 0.3m;
        }
        else
        {
            return Gia + Gia * 0.1m;
        }
    }

    public override string GetInfo()
    {
        return base.GetInfo() 
            + "  |  So cho: " + Socho
            + "  |  Dong co: " + Dtdc + "L";
    }
}

public class XeMay : Pt
{
    private int dtxl;

    public int Dtxl
    {
        get
        {
            return dtxl;
        }
        set
        {
            if(value <= 0)
            {
                throw new ArgumentException("Dung tich xy lanh phai lon hon 0");
            }
            dtxl = value;
        }
    }

    public XeMay(string ma, string ten, int namsx, decimal gia, int dtxl) : base(ma, ten, namsx, gia)
    {
        Dtxl = dtxl;
    }

    public override decimal TinhGiaLanBanh()
    {
        if(Dtxl < 175)
        {
            return Gia + Gia * 0.02m;
        }
        else
        {
            return Gia + Gia * 0.05m;
        }
    }

    public override string GetInfo()
    {
        return base.GetInfo() + "  |  Dung tich xy lanh: " + Dtxl + " cc";
    }
}

public class qlpt
{
    private List<Pt> danhSach;

    public qlpt()
    {
        danhSach = new List<Pt>();
    }

    public void AddPhuongTien(Pt pt)
    {
        if (pt == null)
        {
            throw new ArgumentNullException(
                nameof(pt),
                "Phuong tien khong duoc trong.");
        }

        danhSach.Add(pt);
    }
    public void DisplayAll()
    {
        if (danhSach.Count == 0)
        {
            Console.WriteLine("Danh sach phuong tien dang trong.");
            return;
        }

        foreach (Pt pt in danhSach)
        {
            Console.WriteLine(pt.GetInfo());

            Console.WriteLine(
                $"Giá lăn bánh: {pt.TinhGiaLanBanh():N0} VNĐ");

            Console.WriteLine(
                "--------------------------------------------------");
        }
    }

    public Pt FindMaxGiaLanBanh()
    {
        if (danhSach.Count == 0)
        {
            return null;
        }

        return danhSach
            .OrderByDescending(pt => pt.TinhGiaLanBanh())
            .First();
    }

    public List<Pt> SearchByName(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return new List<Pt>();
        }

        return danhSach
            .Where(pt =>
                pt.Ten.Contains(
                    keyword,
                    StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}

class Program
{
    static void Main()
    {
        qlpt ql = new qlpt();

        Console.WriteLine("===== He thong quan ly phuong tien AutoSpeed =====");

        Console.WriteLine("\n--- Nhap o to ---");

        try
        {
            Console.Write("Ma PT: ");
            string maPT = Console.ReadLine();

            Console.Write("Ten hang: ");
            string tenHang = Console.ReadLine();

            Console.Write("Nam SX: ");
            int namSanXuat = int.Parse(Console.ReadLine());

            Console.Write("Gia goc: ");
            decimal giaGoc = decimal.Parse(Console.ReadLine());

            Console.Write("So cho: ");
            int soChoNgoi = int.Parse(Console.ReadLine());

            Console.Write("Dung tich dong co: ");
            double dungTichDongCo = double.Parse(Console.ReadLine());

            Oto oto = new Oto(
                maPT,
                tenHang,
                namSanXuat,
                giaGoc,
                soChoNgoi,
                dungTichDongCo
            );

            ql.AddPhuongTien(oto);

            Console.WriteLine("\nTao o to thanh cong!");
            Console.WriteLine($"Gia lan banh: {oto.TinhGiaLanBanh():N0} VNĐ");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Loi: {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Loi: Nhap du lieu khong dung dinh dang!");
        }

        Console.WriteLine("\n--- Nhap xe may ---");

        try
        {
            Console.Write("Ma PT: ");
            string maPT = Console.ReadLine();

            Console.Write("Ten hang: ");
            string tenHang = Console.ReadLine();

            Console.Write("Nam SX: ");
            int namSanXuat = int.Parse(Console.ReadLine());

            Console.Write("Gia goc: ");
            decimal giaGoc = decimal.Parse(Console.ReadLine());

            Console.Write("Dung tich xy lanh(cc): ");
            int dungTichXylanh = int.Parse(Console.ReadLine());

            XeMay xeMay = new XeMay(
                maPT,
                tenHang,
                namSanXuat,
                giaGoc,
                dungTichXylanh
            );

            ql.AddPhuongTien(xeMay);

            Console.WriteLine("\nTao xe may thanh cong!");
            Console.WriteLine($"Gia lan banh: {xeMay.TinhGiaLanBanh():N0} VNĐ");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Loi: {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Loi: Nhap du lieu khong dung dinh dang!");
        }

        Console.WriteLine("\n===== Danh sach phuong tien =====");
        ql.DisplayAll();

        Console.WriteLine("\n===== Phuong tien co gia lan banh cao nhat =====");

        Pt max = ql.FindMaxGiaLanBanh();

        if (max != null)
        {
            Console.WriteLine(max.GetInfo());
            Console.WriteLine(
                $"Gia lan banh: {max.TinhGiaLanBanh():N0} VNĐ"
            );
        }

        Console.WriteLine("\nNhan phim bat ky de ket thuc...");
        Console.ReadKey();
    }
}