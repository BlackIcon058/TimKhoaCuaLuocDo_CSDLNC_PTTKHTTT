using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTH_3120410435
{
    public class ThuatToan
    {
        public string TimBaoDong(string baoDong, List<string> trai, List<string> phai)
        {
            

            //trai phai la pth ben trai, pth ben phai
            /*
             
             */
            int doDaiBaoDong = baoDong.Length - 1;
            //toi thieu se co the tinh bao dong cua 1 thuoc tinh don
            while (doDaiBaoDong != baoDong.Length)
            {
                doDaiBaoDong = baoDong.Length;
                
                for (int i = 0; i < trai.Count; i++)
                //tra ve so phan tu hien co trong list
                //trong vi du chay tu 0 toi 3
                {
                    if (SoSanhChuoi(trai[i], baoDong))//so sanh xem chuoi con co nam trong chuoi cha khong
                    {
                        for (int j = 0; j < phai[i].Length; j++)
                            //phai[i] la de xet do dai cua thang ben phai
                            //cai j chi la de chay cua cai tap thuoc tinh ben phai,
                            //vd de, thì j = 0 la d, j = 1 la e
                            //phai10 la ss d voi ab, phai 11 la ss e voi ab
                            //chay tu 0 cho toi 4 luon, vi ben phu thuoc ham ben phai cung co 4
                            if (!SoSanhChuoi(phai[i][j].ToString(), baoDong))
                            {
                                baoDong += phai[i][j].ToString();
                                Console.WriteLine(baoDong + "    (Vi " + trai[i] + " -> " + phai[i][j] + ")");
                            }
                        /*
                         A -> D
                         ab+ 


                        do dai bao dong la n - 1
                        trong vong lap vo tan
                        dat lai do dai ban dau la n
                        cho chay vong lap tu 0 < so phan tu ben trai
                        a -> d
                        neu a la con cua bao dong ab
                        thì xét tiếp, cho chạy từ 0 tới số phần tử bên phải, mục đích là để duyệt 
                        qua các phần tử bên phải

                        neu d ma la con cua bao dong ab, thì khong co gi xay ra, tai vi chỉ có thể 
                        thêm ở bên trái thôi
                        , ngược lại thì 

                        Tức là, bởi vì khi mà ab+, thì nếu mà thêm á, thì chỉ có cách là a kéo theo gì
                        đó, hoặc là b kéo theo gì đó, chứ không đời nào mà d  kéo theo gì đó thì thêm được
                        đó là lý do mà có cái if đầu tiên. 

                        ben phai la mang 2 chieu de xac dinh la của cái dòng phụ thuộc hàm nào
                        */
                    }
                }

            }

            return baoDong;
        }

        private bool SoSanhChuoi(string con, string cha)
        {
            //y tuong: la co cac phan tu nam trong chuoi cha
            int ChuoiCon = 0; //de so sanh

            if (cha.Length < con.Length)
                return false;

            for (int i = 0; i < con.Length; i++)
                for (int j = 0; j < cha.Length; j++)
                {
                    if (con[i] == cha[j])
                    {
                        ChuoiCon++;
                        break;//chay ra khoi for luon
                    }
                }

            if (ChuoiCon == con.Length)//so sanh do dai chuoi con voi do dai thuc su
                return true;

            return false;
        }


        public List<string> TimKhoa(string tapThuocTinh, List<string> trai, List<string> phai)
        {
            List<string> listKhoa = new List<string>();

            string L = "";
            string R = "";
            string TN = "";
            string TG = "";

            //lấy tập L (chỉ xuất hiện vế trái, ko xh vế phải)
            for (int i = 0; i < tapThuocTinh.Length; i++)
            {/*
              vong for dau tien chay trong tap thuoc tinh, chay tu 0 toi 6
              */
                for (int t = 0; t < trai.Count; t++)
                    /* 
                     Vong for nay chay tu 0 toi 4
                     */
                    if (SoSanhChuoi(tapThuocTinh[i].ToString(), trai[t]) && !SoSanhChuoi(tapThuocTinh[i].ToString(), phai[t]))
                    {
                        /*
                         * vong if nay muc dich la tranh cho viec nhap vo cac phu thuoc ham khong co trong tap thuoc tinh
                         tapthuoctinh[i].tostring, vd, abcdef, thì tapthuoctinh[0].tostring thì sẽ là a.
                        rồi nó so sánh với chuỗi cha là tập L. đầu tiên là L[0], là phần tử đầu tiên bên tập trái


                         */
                        L += tapThuocTinh[i].ToString();
                        break;//abceg
                    }
            }
            Console.WriteLine("Tap thuoc tinh ben trai: " + L);

            //lấy tập R (chỉ xuất hiện vế phải, ko xh vế trái)
            for (int i = 0; i < tapThuocTinh.Length; i++)
            {
                for (int t = 0; t < trai.Count; t++)
                    if (SoSanhChuoi(tapThuocTinh[i].ToString(), phai[t]) && !SoSanhChuoi(tapThuocTinh[i].ToString(), trai[t]))
                    {
                        R += tapThuocTinh[i].ToString();
                        break; //cdegbeh
                    }
            }
            Console.WriteLine("Tap thuoc tinh ben phai: " + R);


            /*lấy TN thuộc tính chỉ xuất hiện ở vế trái, không xuất hiện ở vế phải và
             * các thuộc tính không xuất hiện ở cả vế trái và vế phải của F*/

            for (int i = 0; i < tapThuocTinh.Length; i++)
            {
                if (!SoSanhChuoi(tapThuocTinh[i].ToString(), R))
                {
                    TN += tapThuocTinh[i].ToString();//a
                }
            }
            Console.WriteLine("Tap nguon: " + TN);

            //lấy TG (giao giữa 2 tập L và R)
            for (int i = 0; i < L.Length; i++)
            {
                if (SoSanhChuoi(L[i].ToString(), R))
                {
                    TG += L[i].ToString();//bceg
                }
            }
            Console.WriteLine("Tap trung gian: " + TG);

            //BUOC CUOI CUNG, TIM BAO DONG TU TAP DICH VA TAP TRUNG GIAN
            

            
            if (TG == "")
            {
                listKhoa.Add(TN);
                return listKhoa;
            }
            else
            {
                List<string> TapConTG = new List<string>();
                
                TapConTG = TimTapCon(TG);

                List<string> SieuKhoa = new List<string>();

                
                for (int n = 0; n < TapConTG.Count; n++)
                {
                    
                    string temp = TN + TapConTG[n];
                    
                    if (SoSanhChuoi(tapThuocTinh, TimBaoDong(temp, trai, phai)))
                    {
                        SieuKhoa.Add(temp);
                    }
                }

               
                for (int i = 0; i < SieuKhoa.Count; i++)
                {
                    for (int j = i + 1; j < SieuKhoa.Count; j++)
                    {
                        if (SoSanhChuoi(SieuKhoa[i], SieuKhoa[j]))
                        {
                            SieuKhoa.Remove(SieuKhoa[j]);
                            j--;
                        }
                    }
                }

                listKhoa = SieuKhoa;
            }

            return listKhoa;
        }

        List<string> TimTapCon(string str)
        {

            List<string> TapCon = new List<string>();

            int[] a = new int[str.Length];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = 0;
            }

            int t = str.Length - 1;

            TapCon.Add("");
            while (t >= 0)
            {

                t = str.Length - 1;
                while (t >= 0 && a[t] == 1)
                    t--;

                if (t >= 0)
                {
                    a[t] = 1;
                    for (int i = t + 1; i < str.Length; i++)
                        a[i] = 0;

                    string temp = "";
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (a[i] == 1)
                        {
                            temp += str[i];
                        }
                    }

                    TapCon.Add(temp);
                }
            }

            return TapCon;
            
        }

        //Tim mot khoa
        public void TimMotKhoa(string tapThuocTinh, List<string> trai, List<string> phai)
        {
            string temp = null;
            string tapThuocTinhDeSoSanh = tapThuocTinh;

            for (int i=0; i<tapThuocTinh.Length; i++)
            {

                Console.WriteLine("Thu xoa " + tapThuocTinh[i]);
                temp = tapThuocTinh.Remove(i, 1);

                Console.WriteLine("Sau khi xoa, tap thuoc tinh la: " + temp);

                string baodong = TimBaoDong(temp, trai, phai);
                Console.WriteLine("Bao dong la: " + baodong);

                //Console.WriteLine("Tap thuoc tinh de so sanh la:" + tapThuocTinhDeSoSanh);
                if(ktraChuoiGiongNhau(baodong, tapThuocTinhDeSoSanh) && (baodong.Length == tapThuocTinhDeSoSanh.Length))
                {
                    Console.WriteLine("Xoa " + tapThuocTinh[i]);
                    
                    tapThuocTinh = temp;
                    Console.WriteLine("Tap thuoc tinh: " + tapThuocTinh);
                    i--;
                }else
                {
                    Console.WriteLine("Khong xoa duoc " + tapThuocTinh[i]);
                    Console.WriteLine("Tap thuoc tinh: " + tapThuocTinh);
                }
               
                Console.WriteLine();
            }
            Console.WriteLine("Vay khoa can tim la: " + tapThuocTinh);
        }

        public bool ktraChuoiGiongNhau(string str1, string str2)
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



    }
}

    


