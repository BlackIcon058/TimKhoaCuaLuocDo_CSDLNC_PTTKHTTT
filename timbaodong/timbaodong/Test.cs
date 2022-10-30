using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTH_3120410435
{
    public class Test
    {
        public static bool ktraChuoiGiongNhau(string str1, string str2)
        {

            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == str2[i])
                {
                    break;
                }
                else
                {
                    return false;
                }
            }
            return true;

        }

        public static void Main()
        {

            List<string> Khoa = new List<string>();

            ThuatToan tt = new ThuatToan();
            List<string> listTrai = new List<string>();
            List<string> listPhai = new List<string>();

            string strleft =null;
            string strright =null;//nho xoa khoan trang dau chuoi


            Console.WriteLine("Noi dung trong file: ");
            string[] a = File.ReadAllLines("test.txt");

            
            for (int i = 0; i < a.Length; ++i)
            {

                Console.WriteLine(a[i]);
                string temp = a[i];

                for(int j = 0; j< temp.Length; j++)
                {
                    if (temp[j] == '-')
                    {
                        break;
                    }

                    strleft += temp[j];
                    
                }
                listTrai.Add(strleft);
                strleft = null;
                for (int k = temp.Length-1; k >= 0; k--)
                {
                    if (temp[k] == '>')
                    {
                        break;
                    }
                    strright += temp[k];
                    
                }

                listPhai.Add(strright);
                strright = null;
            }
         
            /*
            int n;
            Console.WriteLine("Nhap tong so phu thuoc ham: ");
            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap vao PTH TRAI thu : " + (i + 1) + ":");
                strleft = Console.ReadLine();
                listTrai.Add(strleft);

                Console.WriteLine("Nhap vao PTH PHAI thu : " + (i + 1) + ":");
                strright = Console.ReadLine();
                listPhai.Add(strright);
            }
            */
            Console.WriteLine("Danh sach phu thuoc ham: Trai");
            for (int i = 0; i < listTrai.Count; i++)
            {
                Console.WriteLine(listTrai[i]);
            }
            Console.WriteLine("Danh sach phu thuoc ham: Phai");

            for (int j = 0; j < listPhai.Count; j++)
            {
                Console.WriteLine(listPhai[j]);
            }
            

            Console.WriteLine("Nhap bao dong can tim: ");
            string baodong = Console.ReadLine();
            Console.WriteLine("Loi giai: ");
            Console.WriteLine("Bao dong cua " + baodong + " la: " + tt.TimBaoDong(baodong, listTrai, listPhai));



            //________
            //string str = "abcdegh";

            //Console.WriteLine(str[0].ToString());
            Console.WriteLine();
            Console.WriteLine("Nhap tap thuoc tinh: ");
            string tapthuoctinh = Console.ReadLine();

            Khoa = tt.TimKhoa(tapthuoctinh, listTrai, listPhai);
            Console.WriteLine("Tat ca cac khoa cua luoc do R la: ");
            for (int k = 0; k < Khoa.Count; k++)
            {
                Console.WriteLine(Khoa[k]);
            }

            Console.WriteLine("Tim mot khoa: ");
            //test

            tt.TimMotKhoa(tapthuoctinh, listTrai, listPhai);

            /*string str1 = "quan";
            string str2 = "quan";
            Console.WriteLine(ktraChuoiGiongNhau(str1, str2));*/
        }  
    }
}
