using KreditExsam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreditExsam.Service
{
    public class KreditService : IKreditService
    {
        public async Task<List<Superclass>> KREDIT_GETS(KreditClass credit)
        {
            List<Superclass> alls = new List<Superclass>();

            int t = 0; ;

            while (alls.Count <= 0 && t <= 0)
            {
                double Credit_balansi = credit.KredSumma;

                double Kundalik_Tulov = credit.KundalikTulov;

                double Asosiy_qarz = credit.KredSumma / (double)credit.KredMuddat;

                double Credit_foizi = (double)credit.KredFoiz / 100;

                for (int i = 1; i <= credit.KredMuddat; i++)
                {
                    double Foizi = Credit_balansi * Credit_foizi / credit.KredMuddat;

                    double Jami_oylik_tulov = Asosiy_qarz + Foizi + Kundalik_Tulov;

                    if (credit.OylikMaosh * 0.5 < Jami_oylik_tulov)
                    {
                        credit.KredMuddat = MinCreditOy(credit.KredMuddat, credit.KredSumma, credit.KundalikTulov, Credit_foizi, credit.OylikMaosh);

                        if (credit.KredMuddat > 24)
                        {
                            t++;
                            break;
                        }

                        Asosiy_qarz = (double)credit.KredSumma / credit.KredMuddat;

                        if (credit.KredMuddat > 24)
                        {
                            Credit_balansi = MinCreditSumm(credit.KredSumma, credit.KundalikTulov, Credit_foizi, credit.OylikMaosh);

                            credit.KredMuddat = 24;

                            i = 0;

                            if (Credit_balansi < 2000000)
                            {
                                t++;
                                break;
                            }

                        }

                        i = 0;
                    }

                    else
                    {
                             List<Superclass> models = new List<Superclass>()
                             {
                                  new Superclass() { Oy = i, CreditBalansi = Credit_balansi, AsosiyQarzi = Asosiy_qarz, Foizi = Foizi, JamiOylikTulov = Jami_oylik_tulov }
                             };

                        alls.AddRange(models);

                        Credit_balansi -= Asosiy_qarz;
                    }
                }
            }

            return alls;
        }

        public int MinCreditOy(int Oy_count, double kredit_summ, double kundalik_tulov, double foizi, double Oylik_maosh)
        {
            double Assosiy_qarz = kredit_summ / Oy_count;

            double Foizi = kredit_summ * foizi / Oy_count;

            double Jami_Summ = Assosiy_qarz + Foizi + kundalik_tulov;

            while (Oylik_maosh * 0.5 <= Jami_Summ)
            {
                double Assosiy_qarzz = kredit_summ / Oy_count;

                double Foizii = kredit_summ * foizi / Oy_count;

                double Jami_Summm = Assosiy_qarzz + Foizii + kundalik_tulov;

                Jami_Summ = Jami_Summm;

                Oy_count++;
                if (Oy_count > 24)
                {
                    return Oy_count;
                }
            }

            return Oy_count;
        }
        public double MinCreditSumm(double Kredit_summ, double Kundalik_tulov, double foizi, double Oylik_maosh)
        {
            double Assosiy_qarz = Kredit_summ / 24;

            double Foizi = Kredit_summ * foizi / 24;

            double Jami_summ = Assosiy_qarz + Foizi + Kundalik_tulov;

            while (Oylik_maosh * 0.5 <= Jami_summ)
            {
                double Assosiy_qarzz = Kredit_summ / 24;

                double Foizii = Kredit_summ * foizi / 24;

                double Jami_summm = Assosiy_qarzz + Foizii + Kundalik_tulov;

                Jami_summ = Jami_summm;

                Kredit_summ -= Foizii;
            }

            return Kredit_summ;
        }
    }
}
