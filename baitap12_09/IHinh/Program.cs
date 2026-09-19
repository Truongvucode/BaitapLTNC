using System;

namespace IHinh
{
    public interface IHinh
    {
        double GetDienTich();
        double GetChuVi();
        void Nhap();
        void HienThi();
    }

    public class HinhTron : IHinh
    {
        private double banKinh;

        public double BanKinh
        {
            get { return banKinh; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Bán kính phải > 0");
                banKinh = value;
            }
        }

        public HinhTron()
        {
            banKinh = 1;
        }

        public HinhTron(double banKinh)
        {
            BanKinh = banKinh;
        }

        public double GetDienTich()
        {
            return Math.PI * BanKinh * BanKinh;
        }

        public double GetChuVi()
        {
            return 2 * Math.PI * BanKinh;
        }

        public void Nhap()
        {
            do
            {
                Console.Write("Nhập bán kính: ");
            }
            while (!double.TryParse(Console.ReadLine(), out banKinh) || banKinh <= 0);

            BanKinh = banKinh;
        }

        public void HienThi()
        {
            Console.WriteLine("===== HÌNH TRÒN =====");
            Console.WriteLine($"Bán kính: {BanKinh}");
            Console.WriteLine($"Chu vi: {GetChuVi():F2}");
            Console.WriteLine($"Diện tích: {GetDienTich():F2}");
        }
    }

    public class HinhChuNhat : IHinh
    {
        private double chieuDai;
        private double chieuRong;

        public double ChieuDai
        {
            get { return chieuDai; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Chiều dài phải > 0");
                chieuDai = value;
            }
        }

        public double ChieuRong
        {
            get { return chieuRong; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Chiều rộng phải > 0");
                chieuRong = value;
            }
        }

        public HinhChuNhat()
        {
            ChieuDai = 1;
            ChieuRong = 1;
        }

        public HinhChuNhat(double dai, double rong)
        {
            ChieuDai = dai;
            ChieuRong = rong;
        }

        public double GetDienTich()
        {
            return ChieuDai * ChieuRong;
        }

        public double GetChuVi()
        {
            return 2 * (ChieuDai + ChieuRong);
        }

        public void Nhap()
        {
            do
            {
                Console.Write("Nhập chiều dài: ");
            }
            while (!double.TryParse(Console.ReadLine(), out chieuDai) || chieuDai <= 0);

            do
            {
                Console.Write("Nhập chiều rộng: ");
            }
            while (!double.TryParse(Console.ReadLine(), out chieuRong) || chieuRong <= 0);

            ChieuDai = chieuDai;
            ChieuRong = chieuRong;
        }

        public void HienThi()
        {
            Console.WriteLine("===== HÌNH CHỮ NHẬT =====");
            Console.WriteLine($"Chiều dài: {ChieuDai}");
            Console.WriteLine($"Chiều rộng: {ChieuRong}");
            Console.WriteLine($"Chu vi: {GetChuVi():F2}");
            Console.WriteLine($"Diện tích: {GetDienTich():F2}");
        }
    }

    public class HinhTamGiac : IHinh
    {
        private double a, b, c;

        public double A
        {
            get { return a; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Cạnh phải > 0");
                a = value;
            }
        }

        public double B
        {
            get { return b; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Cạnh phải > 0");
                b = value;
            }
        }

        public double C
        {
            get { return c; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Cạnh phải > 0");
                c = value;
            }
        }

        public HinhTamGiac()
        {
            A = B = C = 1;
        }

        public HinhTamGiac(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;

            if (!IsTamGiac())
                throw new ArgumentException("Ba cạnh không tạo thành tam giác.");
        }

        public bool IsTamGiac()
        {
            return (A + B > C &&
                    A + C > B &&
                    B + C > A);
        }

        public double GetChuVi()
        {
            return A + B + C;
        }

        public double GetDienTich()
        {
            double p = GetChuVi() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public void Nhap()
        {
            do
            {
                Console.Write("Nhập cạnh a: ");
            }
            while (!double.TryParse(Console.ReadLine(), out a) || a <= 0);

            do
            {
                Console.Write("Nhập cạnh b: ");
            }
            while (!double.TryParse(Console.ReadLine(), out b) || b <= 0);

            do
            {
                Console.Write("Nhập cạnh c: ");
            }
            while (!double.TryParse(Console.ReadLine(), out c) || c <= 0);

            A = a;
            B = b;
            C = c;

            while (!IsTamGiac())
            {
                Console.WriteLine("Ba cạnh không tạo thành tam giác. Nhập lại!");

                Console.Write("a = ");
                A = double.Parse(Console.ReadLine());

                Console.Write("b = ");
                B = double.Parse(Console.ReadLine());

                Console.Write("c = ");
                C = double.Parse(Console.ReadLine());
            }
        }

        public void HienThi()
        {
            Console.WriteLine("===== HÌNH TAM GIÁC =====");
            Console.WriteLine($"Ba cạnh: {A}, {B}, {C}");
            Console.WriteLine($"Chu vi: {GetChuVi():F2}");
            Console.WriteLine($"Diện tích: {GetDienTich():F2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IHinh[] dsHinh = new IHinh[3];

            dsHinh[0] = new HinhTron();
            dsHinh[1] = new HinhChuNhat();
            dsHinh[2] = new HinhTamGiac();

            foreach (IHinh h in dsHinh)
            {
                h.Nhap();
                Console.WriteLine();
            }

            Console.WriteLine("\n===== THÔNG TIN CÁC HÌNH =====");

            foreach (IHinh h in dsHinh)
            {
                h.HienThi();
                Console.WriteLine();
            }
        }
    }
}