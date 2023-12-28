using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using HastaneRandevuSistemi.Models;

namespace HastaneRandevuSistemi.Services
{
    public class TimedBackgroundService : BackgroundService
    {
        private readonly ILogger<TimedBackgroundService> _logger;

        ApplicationDbContext timerDbContext = new ApplicationDbContext();

        public TimedBackgroundService(ILogger<TimedBackgroundService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Timed Background Service is working at: {time}", DateTimeOffset.Now);

                bool checkDoktor = timerDbContext.Doktorlar.Any();

                if (checkDoktor)
                {
                    List<Doktor> doktors = timerDbContext.Doktorlar.ToList();
                    foreach (var doktor in doktors)
                    {
                        
                        for (int i = 9; i < 16; i++)
                        {
                            if (i==13)
                            {
                                continue;
                            }
                            else
                            {
                                DateTime suankiTarihVeSaat = DateTime.Now;
                                DateTime randevuTime1 = new DateTime(suankiTarihVeSaat.Year, suankiTarihVeSaat.Month, suankiTarihVeSaat.Day, i, 0, 0).ToUniversalTime();
                                DateTime randevuTime2 = new DateTime(suankiTarihVeSaat.Year, suankiTarihVeSaat.Month, suankiTarihVeSaat.Day, i, 30, 0).ToUniversalTime();
                                int poliklinikId = timerDbContext.Poliklinikler.SingleOrDefault(p => p.DoktorID == doktor.DoktorID).PoliklinikID;
                                int bransId = timerDbContext.Doktorlar.SingleOrDefault(b => b.DoktorID == doktor.DoktorID).BransID;
                                int hastaneId= timerDbContext.Poliklinikler.SingleOrDefault(p => p.DoktorID == doktor.DoktorID).HastaneID;
                                int doktorId = doktor.DoktorID;
                                int muayeneTurıd = (doktor.BransID == 11) ? 1 : 2;
                                
                                Randevu r1 = new Randevu()
                                {
                                    KullaniciID = null,
                                    BransID = bransId,
                                    PoliklinikID=poliklinikId,
                                    HastaneID=hastaneId,
                                    DoktorID=doktorId,
                                    DurumID=4,
                                    MuayeneTurID=muayeneTurıd,
                                    RandevuTarihSaat=randevuTime1
                                };
                                Randevu r2 = new Randevu()
                                {
                                    KullaniciID=null,
                                    BransID = bransId,
                                    PoliklinikID = poliklinikId,
                                    HastaneID = hastaneId,
                                    DoktorID = doktorId,
                                    DurumID = 4,
                                    MuayeneTurID = muayeneTurıd,
                                    RandevuTarihSaat = randevuTime2
                                };
                                
                                timerDbContext.Randevular.Add(r1);
                                timerDbContext.Randevular.Add(r2);
                                
                            }
                        }
                    }
                    timerDbContext.SaveChanges();
                }

                await Task.Delay(TimeSpan.FromDays(1), stoppingToken); 
            }
        }
    }
}

