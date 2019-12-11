using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiriusQuality_SiriusQuality_WheatLAIConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {

                #region Console Write

                int stop = 0;
                Console.WriteLine("*Choose the day after sowing when the simulation have to stop (between 0 and 68)");
                string stopstr = Console.ReadLine();
                stop = Int32.Parse(stopstr);
                stop = Math.Min(68, stop);

                #endregion


                #region Mandatory Inputs

                //Number of emerged leaves on main-stem
                double[] LeafNumber = {0.557647985230187,1.09043931678266,1.43970520699377,1.80873341576133,2.2345041114049,2.75499969754529,
                                   3.34348137255173,3.58343237845917,3.82804047067294,4.07389109047749,4.20521958723891,
                                   4.39091153619138,4.62051162186396,4.88542196610876,5.14716383389326,5.40582137476738,
                                   5.6574039022365,5.86145558052042,6.12062763980613,6.34333884021971,6.54531609460124,
                                   6.71753153709139,6.93924939611125,7.14510347852348,7.34471540144539,7.50567947738435,
                                   7.69972392696081,7.91309331392681,8.08506366377536,8.24526926145251,8.41325732206563,
                                   8.59104313871357,8.74978423398998,8.91945383336118,8.91945383336118,8.91945383336118,
                                   8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,
                                   8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,
                                   8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,
                                   8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,
                                   8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,
                                   8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,
                                   8.91945383336118,8.91945383336118,8.91945383336118};

                //Number of leaves at maturity
                double[] FinalLeafNumber = {0,0,0,0,0,0,
                                        0,0,0,0,0,
                                        0,0,8.79758201319948,8.79758201319948,8.79758201319948,
                                        8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                                        8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                                        8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                                        8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                                        8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                                        8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                                        8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                                        8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                                        8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                                        8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                                        8.79758201319948,8.79758201319948,8.79758201319948};

                //Phyllochron
                double[] Phyllochron = {36.48,36.48,36.48,36.48,
                                    36.48,36.48,36.48,36.48,36.48,
                                    91.2,91.2,91.2,91.2,91.2,
                                    91.2,91.2,91.2,91.2,91.2,
                                    91.2,91.2,91.2,91.2,91.2,
                                    91.2,91.2,91.2,91.2,91.2,
                                    91.2,91.2,114,114,114,
                                    114,114,114,114,114,
                                    114,114,114,114,114,
                                    114,114,114,114,114,
                                    114,114,114,114,114,
                                    114,114,114,114,114,
                                    114,114,114,114,114,
                                    114,114,114,114,114};

                //Daily increase of shoot thermal time
                double[] deltaTTShoot = {20.3429985011972,19.4362277750342,12.7412196749015,13.4621490558403,15.5321149770776,18.9876789824015,
                                     21.4678115042348,21.8835317387586,22.3082580098962,22.4215765261747,11.9771589046418,
                                     16.9351057444655,20.9395278133385,24.1598233951257,23.8708583419468,23.5895677277199,
                                     22.9443265051839,18.609513059493,23.6364918068571,20.3112614777188,18.4203255995954,
                                     15.7060483551019,20.2206687426112,18.773892315995,18.2046073704782,14.679923725633,
                                     17.6968538013731,19.4592880912991,15.6836959061883,18.2634381351946,19.1506389098961,
                                     20.2675830978648,18.0964848615109,19.3423343283172,21.7893939077166,19.2854127879827,
                                     20.2046349607756,18.8331080264541,18.0904934289845,14.2864972429511,13.4975457665717,
                                     15.5099933846258,15.8056060524327,17.0999894230251,18.968828420662,19.7084276956706,
                                     18.3808612134954,17.6569929404518,17.5512091484625,16.9486734285003,17.9557501423195,
                                     18.0133246919647,19.3630413473033,18.4492464572252,18.6716428339012,17.3655500894382,
                                     16.8128222344238,15.1523436391195,17.7568910712895,19.7690870277131,19.4255849454613,
                                     21.2182022418101,20.9577458752311,21.1926239701876,22.4114886477857,23.2541291515213,
                                     23.8603416160884,25.1187578254212,24.1775006707492};

                //Daily increase of thermal time for shoot senescence
                double[] deltaTTSenescence ={18.8634594435474,18.1500566789332,13.4777755158328,13.9502621423481,15.3685641952009,18.1389851581786,
                                         22.0266010363367,24.5139248276334,25.1359791932878,26.4421850402397,79.1780694994322,
                                         48.6348973505465,39.4782779560475,33.1400640780818,31.4103312713857,24.9093394417282,
                                         23.3990685778994,18.1388262431556,26.4039644345343,25.417846953636,17.7160119018876,
                                         15.5886370376346,21.1518890356991,19.2417637865416,18.2647680380178,14.8314614940969,
                                         17.0271575547693,19.6334867977361,15.5570736348724,18.1052370501955,19.453058145847,
                                         19.9402361913259,18.813277090531,19.8761017939972,21.0420528597581,19.3566957025082,
                                         19.4102110733471,18.7605233543128,17.4181579905026,14.5147347216922,13.9258694652509,
                                         15.5401937479469,16.1666390113438,17.3616322900991,19.6281838713623,20.8075067062811,
                                         21.1365339172969,20.485853186253,20.2272681178316,19.7701715689887,20.5324776806292,
                                         20.5875547312483,21.568684643984,20.9078125455239,21.1058621219476,20.0808471198446,
                                         19.7605105285675,18.4979567416476,20.4233741386655,22.1102608146914,22.1735427281863,
                                         23.8981292487473,24.7697303746329,24.8518879002076,26.6275128225516,31.9302317846317,
                                         33.8746521838111,35.0663191713763,56.9171875154658};

                //Fraction of available water
                double[] FPAW ={0,0.649330294130382,0.949276961563336,0.701422826218318,0.432359593879618,0.416229768174604,
                            0.301795625715249,0.371060772939269,0.301513295591457,1,0.928520911655553,
                            0.834733893557423,0.769093526923454,0.692957907378058,0.670753326869614,0.617877307891267,
                            0.527219138453055,0.826721095302961,0.975888003772517,0.940000765756517,0.901626302244651,
                            0.880712043775198,0.818244014336879,0.728198192425797,0.645137268825276,0.61122670795734,
                            0.599100625314139,0.534251688763018,0.602705675958155,0.778825506395038,0.957554611917848,
                            1,1,0.995674866378559,0.98652254279641,0.980103426343702,
                            0.948101145687831,1,1,1,1,
                            0.997664520330639,0.991486540306202,0.984989480313322,0.939664139078174,0.977874975071588,
                            1,1,1,0.997745700970875,0.991221896875646,
                            0.936463476664884,0.859023420146995,0.979186122809167,0.980717245099236,0.977537759193708,
                            0.917206180273985,0.838755936599912,0.927586196418915,0.966377668533729,0.967739621814425,
                            0.957600341629398,0.944487732189159,0.896147157650712,0.812831321539017,0.740974083311826,
                            0.677078643964339,0.900341278376329,0.870617800735546};

                //Vapour Pressure Deficit Air-Canopy
                double[] VPDairCanopy ={10.5501650190894,14.8644139988299,16.7183676163284,10.4713881793923,9.48083039035241,11.6851646225725,
                                    16.369549681592,24.489550502406,27.5359499895846,27.2359597458044,28.0564153720671,
                                    71.2472990524233,46.3871062631055,37.5081701489102,29.7617946718002,29.9207540729397,
                                    24.8195451114348,24.2331791511647,14.5721746022972,29.1430660093613,29.2575393219729,
                                    15.0192877234668,11.5083147937107,23.9769447537411,23.8678716264757,20.3802960510982,
                                    9.40640596104836,13.1475633162137,20.2461360558172,12.4254744696398,17.6520892520655,
                                    20.5359563318103,20.5158522158533,19.0294748353469,17.8650961595892,19.8700816169116,
                                    17.1940902411711,15.2898080020044,18.9943986590336,15.506594450611,12.8159308760444,
                                    12.7926191241,14.6064674301253,15.518981101098,16.661669010001,21.838018095937,
                                    23.5358238514393,23.5406117227996,23.5368547536741,22.9009495674441,19.2827385606521,
                                    19.9907030426549,17.9485775352386,23.349138459886,21.5492747217218,23.0364246520804,
                                    19.9934950471457,17.1853114622997,13.8273604126534,18.7591027877483,22.841151100524,
                                    23.4765797495594,25.5903541615547,27.932972641129,28.6899989992148,30.0523630593338,
                                    34.2787198183646,35.7551877899627,35.7486144022789};

                //Store the density of new tiller (main-stem +tillers) created at each time a new tiller appears
                List<List<double>> tilleringProfile = new List<List<double>>();

                #region Valorize List tilleringProfile
                tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>()); tilleringProfile.Add(new List<double>());
                tilleringProfile[0].Add(288);
                tilleringProfile[1].Add(288);
                tilleringProfile[2].Add(288);
                tilleringProfile[3].Add(288);
                tilleringProfile[4].Add(288);
                tilleringProfile[5].Add(288);
                tilleringProfile[6].Add(288); tilleringProfile[6].Add(288);
                tilleringProfile[7].Add(288); tilleringProfile[7].Add(288);
                tilleringProfile[8].Add(288); tilleringProfile[8].Add(288);
                tilleringProfile[9].Add(288); tilleringProfile[9].Add(288); tilleringProfile[9].Add(24);
                tilleringProfile[10].Add(288); tilleringProfile[10].Add(288); tilleringProfile[10].Add(24);
                tilleringProfile[11].Add(288); tilleringProfile[11].Add(288); tilleringProfile[11].Add(24);
                tilleringProfile[12].Add(288); tilleringProfile[12].Add(288); tilleringProfile[12].Add(24);
                tilleringProfile[13].Add(288); tilleringProfile[13].Add(288); tilleringProfile[13].Add(24);
                tilleringProfile[14].Add(288); tilleringProfile[14].Add(288); tilleringProfile[14].Add(24);
                tilleringProfile[15].Add(288); tilleringProfile[15].Add(288); tilleringProfile[15].Add(24);
                tilleringProfile[16].Add(288); tilleringProfile[16].Add(288); tilleringProfile[16].Add(24);
                tilleringProfile[17].Add(288); tilleringProfile[17].Add(288); tilleringProfile[17].Add(24);
                tilleringProfile[18].Add(288); tilleringProfile[18].Add(288); tilleringProfile[18].Add(24);
                tilleringProfile[19].Add(288); tilleringProfile[19].Add(288); tilleringProfile[19].Add(24);
                tilleringProfile[20].Add(288); tilleringProfile[20].Add(288); tilleringProfile[20].Add(24);
                tilleringProfile[21].Add(288); tilleringProfile[21].Add(288); tilleringProfile[21].Add(24);
                tilleringProfile[22].Add(288); tilleringProfile[22].Add(288); tilleringProfile[22].Add(24);
                tilleringProfile[23].Add(288); tilleringProfile[23].Add(288); tilleringProfile[23].Add(24);
                tilleringProfile[24].Add(288); tilleringProfile[24].Add(288); tilleringProfile[24].Add(24);
                tilleringProfile[25].Add(288); tilleringProfile[25].Add(288); tilleringProfile[25].Add(24);
                tilleringProfile[26].Add(288); tilleringProfile[26].Add(288); tilleringProfile[26].Add(24);
                tilleringProfile[27].Add(288); tilleringProfile[27].Add(288); tilleringProfile[27].Add(24);
                tilleringProfile[28].Add(288); tilleringProfile[28].Add(288); tilleringProfile[28].Add(24);
                tilleringProfile[29].Add(288); tilleringProfile[29].Add(288); tilleringProfile[29].Add(24);
                tilleringProfile[30].Add(288); tilleringProfile[30].Add(288); tilleringProfile[30].Add(24);
                tilleringProfile[31].Add(288); tilleringProfile[31].Add(288); tilleringProfile[31].Add(24);
                tilleringProfile[32].Add(288); tilleringProfile[32].Add(288); tilleringProfile[32].Add(24);
                tilleringProfile[33].Add(288); tilleringProfile[33].Add(288); tilleringProfile[33].Add(24);
                tilleringProfile[34].Add(288); tilleringProfile[34].Add(288); tilleringProfile[34].Add(24);
                tilleringProfile[35].Add(288); tilleringProfile[35].Add(288); tilleringProfile[35].Add(24);
                tilleringProfile[36].Add(288); tilleringProfile[36].Add(288); tilleringProfile[36].Add(24);
                tilleringProfile[37].Add(288); tilleringProfile[37].Add(288); tilleringProfile[37].Add(24);
                tilleringProfile[38].Add(288); tilleringProfile[38].Add(288); tilleringProfile[38].Add(24);
                tilleringProfile[39].Add(288); tilleringProfile[39].Add(288); tilleringProfile[39].Add(24);
                tilleringProfile[40].Add(288); tilleringProfile[40].Add(288); tilleringProfile[40].Add(24);
                tilleringProfile[41].Add(288); tilleringProfile[41].Add(288); tilleringProfile[41].Add(24);
                tilleringProfile[42].Add(288); tilleringProfile[42].Add(288); tilleringProfile[42].Add(24);
                tilleringProfile[43].Add(288); tilleringProfile[43].Add(288); tilleringProfile[43].Add(24);
                tilleringProfile[44].Add(288); tilleringProfile[44].Add(288); tilleringProfile[44].Add(24);
                tilleringProfile[45].Add(288); tilleringProfile[45].Add(288); tilleringProfile[45].Add(24);
                tilleringProfile[46].Add(288); tilleringProfile[46].Add(288); tilleringProfile[46].Add(24);
                tilleringProfile[47].Add(288); tilleringProfile[47].Add(288); tilleringProfile[47].Add(24);
                tilleringProfile[48].Add(288); tilleringProfile[48].Add(288); tilleringProfile[48].Add(24);
                tilleringProfile[49].Add(288); tilleringProfile[49].Add(288); tilleringProfile[49].Add(24);
                tilleringProfile[50].Add(288); tilleringProfile[50].Add(288); tilleringProfile[50].Add(24);
                tilleringProfile[51].Add(288); tilleringProfile[51].Add(288); tilleringProfile[51].Add(24);
                tilleringProfile[52].Add(288); tilleringProfile[52].Add(288); tilleringProfile[52].Add(24);
                tilleringProfile[53].Add(288); tilleringProfile[53].Add(288); tilleringProfile[53].Add(24);
                tilleringProfile[54].Add(288); tilleringProfile[54].Add(288); tilleringProfile[54].Add(24);
                tilleringProfile[55].Add(288); tilleringProfile[55].Add(288); tilleringProfile[55].Add(24);
                tilleringProfile[56].Add(288); tilleringProfile[56].Add(288); tilleringProfile[56].Add(24);
                tilleringProfile[57].Add(288); tilleringProfile[57].Add(288); tilleringProfile[57].Add(24);
                tilleringProfile[58].Add(288); tilleringProfile[58].Add(288); tilleringProfile[58].Add(24);
                tilleringProfile[59].Add(288); tilleringProfile[59].Add(288); tilleringProfile[59].Add(24);
                tilleringProfile[60].Add(288); tilleringProfile[60].Add(288); tilleringProfile[60].Add(24);
                tilleringProfile[61].Add(288); tilleringProfile[61].Add(288); tilleringProfile[61].Add(24);
                tilleringProfile[62].Add(288); tilleringProfile[62].Add(288); tilleringProfile[62].Add(24);
                tilleringProfile[63].Add(288); tilleringProfile[63].Add(288); tilleringProfile[63].Add(24);
                tilleringProfile[64].Add(288); tilleringProfile[64].Add(288); tilleringProfile[64].Add(24);
                tilleringProfile[65].Add(288); tilleringProfile[65].Add(288); tilleringProfile[65].Add(24);
                tilleringProfile[66].Add(288); tilleringProfile[66].Add(288); tilleringProfile[66].Add(24);
                tilleringProfile[67].Add(288); tilleringProfile[67].Add(288); tilleringProfile[67].Add(24);
                tilleringProfile[68].Add(288); tilleringProfile[68].Add(288); tilleringProfile[68].Add(24);
                #endregion
                //Store the number of tillers (main-stem +tillers) for each leaf layer
                List<List<double>> leafTillerNumberArray = new List<List<double>>();

                #region Valorize List leafTillerNumberArray
                leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>()); leafTillerNumberArray.Add(new List<double>());
                leafTillerNumberArray[0].Add(1);
                leafTillerNumberArray[1].Add(1); leafTillerNumberArray[1].Add(1);
                leafTillerNumberArray[2].Add(1); leafTillerNumberArray[2].Add(1);
                leafTillerNumberArray[3].Add(1); leafTillerNumberArray[3].Add(1);
                leafTillerNumberArray[4].Add(1); leafTillerNumberArray[4].Add(1); leafTillerNumberArray[4].Add(1);
                leafTillerNumberArray[5].Add(1); leafTillerNumberArray[5].Add(1); leafTillerNumberArray[5].Add(1);
                leafTillerNumberArray[6].Add(1); leafTillerNumberArray[6].Add(1); leafTillerNumberArray[6].Add(1); leafTillerNumberArray[6].Add(2);
                leafTillerNumberArray[7].Add(1); leafTillerNumberArray[7].Add(1); leafTillerNumberArray[7].Add(1); leafTillerNumberArray[7].Add(2);
                leafTillerNumberArray[8].Add(1); leafTillerNumberArray[8].Add(1); leafTillerNumberArray[8].Add(1); leafTillerNumberArray[8].Add(2);
                leafTillerNumberArray[9].Add(1); leafTillerNumberArray[9].Add(1); leafTillerNumberArray[9].Add(1); leafTillerNumberArray[9].Add(2); leafTillerNumberArray[9].Add(3);
                leafTillerNumberArray[10].Add(1); leafTillerNumberArray[10].Add(1); leafTillerNumberArray[10].Add(1); leafTillerNumberArray[10].Add(2); leafTillerNumberArray[10].Add(3);
                leafTillerNumberArray[11].Add(1); leafTillerNumberArray[11].Add(1); leafTillerNumberArray[11].Add(1); leafTillerNumberArray[11].Add(2); leafTillerNumberArray[11].Add(3);
                leafTillerNumberArray[12].Add(1); leafTillerNumberArray[12].Add(1); leafTillerNumberArray[12].Add(1); leafTillerNumberArray[12].Add(2); leafTillerNumberArray[12].Add(3);
                leafTillerNumberArray[13].Add(1); leafTillerNumberArray[13].Add(1); leafTillerNumberArray[13].Add(1); leafTillerNumberArray[13].Add(2); leafTillerNumberArray[13].Add(3);
                leafTillerNumberArray[14].Add(1); leafTillerNumberArray[14].Add(1); leafTillerNumberArray[14].Add(1); leafTillerNumberArray[14].Add(2); leafTillerNumberArray[14].Add(3); leafTillerNumberArray[14].Add(3);
                leafTillerNumberArray[15].Add(1); leafTillerNumberArray[15].Add(1); leafTillerNumberArray[15].Add(1); leafTillerNumberArray[15].Add(2); leafTillerNumberArray[15].Add(3); leafTillerNumberArray[15].Add(3);
                leafTillerNumberArray[16].Add(1); leafTillerNumberArray[16].Add(1); leafTillerNumberArray[16].Add(1); leafTillerNumberArray[16].Add(2); leafTillerNumberArray[16].Add(3); leafTillerNumberArray[16].Add(3);
                leafTillerNumberArray[17].Add(1); leafTillerNumberArray[17].Add(1); leafTillerNumberArray[17].Add(1); leafTillerNumberArray[17].Add(2); leafTillerNumberArray[17].Add(3); leafTillerNumberArray[17].Add(3);
                leafTillerNumberArray[18].Add(1); leafTillerNumberArray[18].Add(1); leafTillerNumberArray[18].Add(1); leafTillerNumberArray[18].Add(2); leafTillerNumberArray[18].Add(3); leafTillerNumberArray[18].Add(3); leafTillerNumberArray[18].Add(3);
                leafTillerNumberArray[19].Add(1); leafTillerNumberArray[19].Add(1); leafTillerNumberArray[19].Add(1); leafTillerNumberArray[19].Add(2); leafTillerNumberArray[19].Add(3); leafTillerNumberArray[19].Add(3); leafTillerNumberArray[19].Add(3);
                leafTillerNumberArray[20].Add(1); leafTillerNumberArray[20].Add(1); leafTillerNumberArray[20].Add(1); leafTillerNumberArray[20].Add(2); leafTillerNumberArray[20].Add(3); leafTillerNumberArray[20].Add(3); leafTillerNumberArray[20].Add(3);
                leafTillerNumberArray[21].Add(1); leafTillerNumberArray[21].Add(1); leafTillerNumberArray[21].Add(1); leafTillerNumberArray[21].Add(2); leafTillerNumberArray[21].Add(3); leafTillerNumberArray[21].Add(3); leafTillerNumberArray[21].Add(3);
                leafTillerNumberArray[22].Add(1); leafTillerNumberArray[22].Add(1); leafTillerNumberArray[22].Add(1); leafTillerNumberArray[22].Add(2); leafTillerNumberArray[22].Add(3); leafTillerNumberArray[22].Add(3); leafTillerNumberArray[22].Add(3);
                leafTillerNumberArray[23].Add(1); leafTillerNumberArray[23].Add(1); leafTillerNumberArray[23].Add(1); leafTillerNumberArray[23].Add(2); leafTillerNumberArray[23].Add(3); leafTillerNumberArray[23].Add(3); leafTillerNumberArray[23].Add(3); leafTillerNumberArray[23].Add(3);
                leafTillerNumberArray[24].Add(1); leafTillerNumberArray[24].Add(1); leafTillerNumberArray[24].Add(1); leafTillerNumberArray[24].Add(2); leafTillerNumberArray[24].Add(3); leafTillerNumberArray[24].Add(3); leafTillerNumberArray[24].Add(3); leafTillerNumberArray[24].Add(3);
                leafTillerNumberArray[25].Add(1); leafTillerNumberArray[25].Add(1); leafTillerNumberArray[25].Add(1); leafTillerNumberArray[25].Add(2); leafTillerNumberArray[25].Add(3); leafTillerNumberArray[25].Add(3); leafTillerNumberArray[25].Add(3); leafTillerNumberArray[25].Add(3);
                leafTillerNumberArray[26].Add(1); leafTillerNumberArray[26].Add(1); leafTillerNumberArray[26].Add(1); leafTillerNumberArray[26].Add(2); leafTillerNumberArray[26].Add(3); leafTillerNumberArray[26].Add(3); leafTillerNumberArray[26].Add(3); leafTillerNumberArray[26].Add(3);
                leafTillerNumberArray[27].Add(1); leafTillerNumberArray[27].Add(1); leafTillerNumberArray[27].Add(1); leafTillerNumberArray[27].Add(2); leafTillerNumberArray[27].Add(3); leafTillerNumberArray[27].Add(3); leafTillerNumberArray[27].Add(3); leafTillerNumberArray[27].Add(3);
                leafTillerNumberArray[28].Add(1); leafTillerNumberArray[28].Add(1); leafTillerNumberArray[28].Add(1); leafTillerNumberArray[28].Add(2); leafTillerNumberArray[28].Add(3); leafTillerNumberArray[28].Add(3); leafTillerNumberArray[28].Add(3); leafTillerNumberArray[28].Add(3); leafTillerNumberArray[28].Add(3);
                leafTillerNumberArray[29].Add(1); leafTillerNumberArray[29].Add(1); leafTillerNumberArray[29].Add(1); leafTillerNumberArray[29].Add(2); leafTillerNumberArray[29].Add(3); leafTillerNumberArray[29].Add(3); leafTillerNumberArray[29].Add(3); leafTillerNumberArray[29].Add(3); leafTillerNumberArray[29].Add(3);
                leafTillerNumberArray[30].Add(1); leafTillerNumberArray[30].Add(1); leafTillerNumberArray[30].Add(1); leafTillerNumberArray[30].Add(2); leafTillerNumberArray[30].Add(3); leafTillerNumberArray[30].Add(3); leafTillerNumberArray[30].Add(3); leafTillerNumberArray[30].Add(3); leafTillerNumberArray[30].Add(3);
                leafTillerNumberArray[31].Add(1); leafTillerNumberArray[31].Add(1); leafTillerNumberArray[31].Add(1); leafTillerNumberArray[31].Add(2); leafTillerNumberArray[31].Add(3); leafTillerNumberArray[31].Add(3); leafTillerNumberArray[31].Add(3); leafTillerNumberArray[31].Add(3); leafTillerNumberArray[31].Add(3);
                leafTillerNumberArray[32].Add(1); leafTillerNumberArray[32].Add(1); leafTillerNumberArray[32].Add(1); leafTillerNumberArray[32].Add(2); leafTillerNumberArray[32].Add(3); leafTillerNumberArray[32].Add(3); leafTillerNumberArray[32].Add(3); leafTillerNumberArray[32].Add(3); leafTillerNumberArray[32].Add(3);
                leafTillerNumberArray[33].Add(1); leafTillerNumberArray[33].Add(1); leafTillerNumberArray[33].Add(1); leafTillerNumberArray[33].Add(2); leafTillerNumberArray[33].Add(3); leafTillerNumberArray[33].Add(3); leafTillerNumberArray[33].Add(3); leafTillerNumberArray[33].Add(3); leafTillerNumberArray[33].Add(3);
                leafTillerNumberArray[34].Add(1); leafTillerNumberArray[34].Add(1); leafTillerNumberArray[34].Add(1); leafTillerNumberArray[34].Add(2); leafTillerNumberArray[34].Add(3); leafTillerNumberArray[34].Add(3); leafTillerNumberArray[34].Add(3); leafTillerNumberArray[34].Add(3); leafTillerNumberArray[34].Add(3);
                leafTillerNumberArray[35].Add(1); leafTillerNumberArray[35].Add(1); leafTillerNumberArray[35].Add(1); leafTillerNumberArray[35].Add(2); leafTillerNumberArray[35].Add(3); leafTillerNumberArray[35].Add(3); leafTillerNumberArray[35].Add(3); leafTillerNumberArray[35].Add(3); leafTillerNumberArray[35].Add(3);
                leafTillerNumberArray[36].Add(1); leafTillerNumberArray[36].Add(1); leafTillerNumberArray[36].Add(1); leafTillerNumberArray[36].Add(2); leafTillerNumberArray[36].Add(3); leafTillerNumberArray[36].Add(3); leafTillerNumberArray[36].Add(3); leafTillerNumberArray[36].Add(3); leafTillerNumberArray[36].Add(3);
                leafTillerNumberArray[37].Add(1); leafTillerNumberArray[37].Add(1); leafTillerNumberArray[37].Add(1); leafTillerNumberArray[37].Add(2); leafTillerNumberArray[37].Add(3); leafTillerNumberArray[37].Add(3); leafTillerNumberArray[37].Add(3); leafTillerNumberArray[37].Add(3); leafTillerNumberArray[37].Add(3);
                leafTillerNumberArray[38].Add(1); leafTillerNumberArray[38].Add(1); leafTillerNumberArray[38].Add(1); leafTillerNumberArray[38].Add(2); leafTillerNumberArray[38].Add(3); leafTillerNumberArray[38].Add(3); leafTillerNumberArray[38].Add(3); leafTillerNumberArray[38].Add(3); leafTillerNumberArray[38].Add(3);
                leafTillerNumberArray[39].Add(1); leafTillerNumberArray[39].Add(1); leafTillerNumberArray[39].Add(1); leafTillerNumberArray[39].Add(2); leafTillerNumberArray[39].Add(3); leafTillerNumberArray[39].Add(3); leafTillerNumberArray[39].Add(3); leafTillerNumberArray[39].Add(3); leafTillerNumberArray[39].Add(3);
                leafTillerNumberArray[40].Add(1); leafTillerNumberArray[40].Add(1); leafTillerNumberArray[40].Add(1); leafTillerNumberArray[40].Add(2); leafTillerNumberArray[40].Add(3); leafTillerNumberArray[40].Add(3); leafTillerNumberArray[40].Add(3); leafTillerNumberArray[40].Add(3); leafTillerNumberArray[40].Add(3);
                leafTillerNumberArray[41].Add(1); leafTillerNumberArray[41].Add(1); leafTillerNumberArray[41].Add(1); leafTillerNumberArray[41].Add(2); leafTillerNumberArray[41].Add(3); leafTillerNumberArray[41].Add(3); leafTillerNumberArray[41].Add(3); leafTillerNumberArray[41].Add(3); leafTillerNumberArray[41].Add(3);
                leafTillerNumberArray[42].Add(1); leafTillerNumberArray[42].Add(1); leafTillerNumberArray[42].Add(1); leafTillerNumberArray[42].Add(2); leafTillerNumberArray[42].Add(3); leafTillerNumberArray[42].Add(3); leafTillerNumberArray[42].Add(3); leafTillerNumberArray[42].Add(3); leafTillerNumberArray[42].Add(3);
                leafTillerNumberArray[43].Add(1); leafTillerNumberArray[43].Add(1); leafTillerNumberArray[43].Add(1); leafTillerNumberArray[43].Add(2); leafTillerNumberArray[43].Add(3); leafTillerNumberArray[43].Add(3); leafTillerNumberArray[43].Add(3); leafTillerNumberArray[43].Add(3); leafTillerNumberArray[43].Add(3);
                leafTillerNumberArray[44].Add(1); leafTillerNumberArray[44].Add(1); leafTillerNumberArray[44].Add(1); leafTillerNumberArray[44].Add(2); leafTillerNumberArray[44].Add(3); leafTillerNumberArray[44].Add(3); leafTillerNumberArray[44].Add(3); leafTillerNumberArray[44].Add(3); leafTillerNumberArray[44].Add(3);
                leafTillerNumberArray[45].Add(1); leafTillerNumberArray[45].Add(1); leafTillerNumberArray[45].Add(1); leafTillerNumberArray[45].Add(2); leafTillerNumberArray[45].Add(3); leafTillerNumberArray[45].Add(3); leafTillerNumberArray[45].Add(3); leafTillerNumberArray[45].Add(3); leafTillerNumberArray[45].Add(3);
                leafTillerNumberArray[46].Add(1); leafTillerNumberArray[46].Add(1); leafTillerNumberArray[46].Add(1); leafTillerNumberArray[46].Add(2); leafTillerNumberArray[46].Add(3); leafTillerNumberArray[46].Add(3); leafTillerNumberArray[46].Add(3); leafTillerNumberArray[46].Add(3); leafTillerNumberArray[46].Add(3);
                leafTillerNumberArray[47].Add(1); leafTillerNumberArray[47].Add(1); leafTillerNumberArray[47].Add(1); leafTillerNumberArray[47].Add(2); leafTillerNumberArray[47].Add(3); leafTillerNumberArray[47].Add(3); leafTillerNumberArray[47].Add(3); leafTillerNumberArray[47].Add(3); leafTillerNumberArray[47].Add(3);
                leafTillerNumberArray[48].Add(1); leafTillerNumberArray[48].Add(1); leafTillerNumberArray[48].Add(1); leafTillerNumberArray[48].Add(2); leafTillerNumberArray[48].Add(3); leafTillerNumberArray[48].Add(3); leafTillerNumberArray[48].Add(3); leafTillerNumberArray[48].Add(3); leafTillerNumberArray[48].Add(3);
                leafTillerNumberArray[49].Add(1); leafTillerNumberArray[49].Add(1); leafTillerNumberArray[49].Add(1); leafTillerNumberArray[49].Add(2); leafTillerNumberArray[49].Add(3); leafTillerNumberArray[49].Add(3); leafTillerNumberArray[49].Add(3); leafTillerNumberArray[49].Add(3); leafTillerNumberArray[49].Add(3);
                leafTillerNumberArray[50].Add(1); leafTillerNumberArray[50].Add(1); leafTillerNumberArray[50].Add(1); leafTillerNumberArray[50].Add(2); leafTillerNumberArray[50].Add(3); leafTillerNumberArray[50].Add(3); leafTillerNumberArray[50].Add(3); leafTillerNumberArray[50].Add(3); leafTillerNumberArray[50].Add(3);
                leafTillerNumberArray[51].Add(1); leafTillerNumberArray[51].Add(1); leafTillerNumberArray[51].Add(1); leafTillerNumberArray[51].Add(2); leafTillerNumberArray[51].Add(3); leafTillerNumberArray[51].Add(3); leafTillerNumberArray[51].Add(3); leafTillerNumberArray[51].Add(3); leafTillerNumberArray[51].Add(3);
                leafTillerNumberArray[52].Add(1); leafTillerNumberArray[52].Add(1); leafTillerNumberArray[52].Add(1); leafTillerNumberArray[52].Add(2); leafTillerNumberArray[52].Add(3); leafTillerNumberArray[52].Add(3); leafTillerNumberArray[52].Add(3); leafTillerNumberArray[52].Add(3); leafTillerNumberArray[52].Add(3);
                leafTillerNumberArray[53].Add(1); leafTillerNumberArray[53].Add(1); leafTillerNumberArray[53].Add(1); leafTillerNumberArray[53].Add(2); leafTillerNumberArray[53].Add(3); leafTillerNumberArray[53].Add(3); leafTillerNumberArray[53].Add(3); leafTillerNumberArray[53].Add(3); leafTillerNumberArray[53].Add(3);
                leafTillerNumberArray[54].Add(1); leafTillerNumberArray[54].Add(1); leafTillerNumberArray[54].Add(1); leafTillerNumberArray[54].Add(2); leafTillerNumberArray[54].Add(3); leafTillerNumberArray[54].Add(3); leafTillerNumberArray[54].Add(3); leafTillerNumberArray[54].Add(3); leafTillerNumberArray[54].Add(3);
                leafTillerNumberArray[55].Add(1); leafTillerNumberArray[55].Add(1); leafTillerNumberArray[55].Add(1); leafTillerNumberArray[55].Add(2); leafTillerNumberArray[55].Add(3); leafTillerNumberArray[55].Add(3); leafTillerNumberArray[55].Add(3); leafTillerNumberArray[55].Add(3); leafTillerNumberArray[55].Add(3);
                leafTillerNumberArray[56].Add(1); leafTillerNumberArray[56].Add(1); leafTillerNumberArray[56].Add(1); leafTillerNumberArray[56].Add(2); leafTillerNumberArray[56].Add(3); leafTillerNumberArray[56].Add(3); leafTillerNumberArray[56].Add(3); leafTillerNumberArray[56].Add(3); leafTillerNumberArray[56].Add(3);
                leafTillerNumberArray[57].Add(1); leafTillerNumberArray[57].Add(1); leafTillerNumberArray[57].Add(1); leafTillerNumberArray[57].Add(2); leafTillerNumberArray[57].Add(3); leafTillerNumberArray[57].Add(3); leafTillerNumberArray[57].Add(3); leafTillerNumberArray[57].Add(3); leafTillerNumberArray[57].Add(3);
                leafTillerNumberArray[58].Add(1); leafTillerNumberArray[58].Add(1); leafTillerNumberArray[58].Add(1); leafTillerNumberArray[58].Add(2); leafTillerNumberArray[58].Add(3); leafTillerNumberArray[58].Add(3); leafTillerNumberArray[58].Add(3); leafTillerNumberArray[58].Add(3); leafTillerNumberArray[58].Add(3);
                leafTillerNumberArray[59].Add(1); leafTillerNumberArray[59].Add(1); leafTillerNumberArray[59].Add(1); leafTillerNumberArray[59].Add(2); leafTillerNumberArray[59].Add(3); leafTillerNumberArray[59].Add(3); leafTillerNumberArray[59].Add(3); leafTillerNumberArray[59].Add(3); leafTillerNumberArray[59].Add(3);
                leafTillerNumberArray[60].Add(1); leafTillerNumberArray[60].Add(1); leafTillerNumberArray[60].Add(1); leafTillerNumberArray[60].Add(2); leafTillerNumberArray[60].Add(3); leafTillerNumberArray[60].Add(3); leafTillerNumberArray[60].Add(3); leafTillerNumberArray[60].Add(3); leafTillerNumberArray[60].Add(3);
                leafTillerNumberArray[61].Add(1); leafTillerNumberArray[61].Add(1); leafTillerNumberArray[61].Add(1); leafTillerNumberArray[61].Add(2); leafTillerNumberArray[61].Add(3); leafTillerNumberArray[61].Add(3); leafTillerNumberArray[61].Add(3); leafTillerNumberArray[61].Add(3); leafTillerNumberArray[61].Add(3);
                leafTillerNumberArray[62].Add(1); leafTillerNumberArray[62].Add(1); leafTillerNumberArray[62].Add(1); leafTillerNumberArray[62].Add(2); leafTillerNumberArray[62].Add(3); leafTillerNumberArray[62].Add(3); leafTillerNumberArray[62].Add(3); leafTillerNumberArray[62].Add(3); leafTillerNumberArray[62].Add(3);
                leafTillerNumberArray[63].Add(1); leafTillerNumberArray[63].Add(1); leafTillerNumberArray[63].Add(1); leafTillerNumberArray[63].Add(2); leafTillerNumberArray[63].Add(3); leafTillerNumberArray[63].Add(3); leafTillerNumberArray[63].Add(3); leafTillerNumberArray[63].Add(3); leafTillerNumberArray[63].Add(3);
                leafTillerNumberArray[64].Add(1); leafTillerNumberArray[64].Add(1); leafTillerNumberArray[64].Add(1); leafTillerNumberArray[64].Add(2); leafTillerNumberArray[64].Add(3); leafTillerNumberArray[64].Add(3); leafTillerNumberArray[64].Add(3); leafTillerNumberArray[64].Add(3); leafTillerNumberArray[64].Add(3);
                leafTillerNumberArray[65].Add(1); leafTillerNumberArray[65].Add(1); leafTillerNumberArray[65].Add(1); leafTillerNumberArray[65].Add(2); leafTillerNumberArray[65].Add(3); leafTillerNumberArray[65].Add(3); leafTillerNumberArray[65].Add(3); leafTillerNumberArray[65].Add(3); leafTillerNumberArray[65].Add(3);
                leafTillerNumberArray[66].Add(1); leafTillerNumberArray[66].Add(1); leafTillerNumberArray[66].Add(1); leafTillerNumberArray[66].Add(2); leafTillerNumberArray[66].Add(3); leafTillerNumberArray[66].Add(3); leafTillerNumberArray[66].Add(3); leafTillerNumberArray[66].Add(3); leafTillerNumberArray[66].Add(3);
                leafTillerNumberArray[67].Add(1); leafTillerNumberArray[67].Add(1); leafTillerNumberArray[67].Add(1); leafTillerNumberArray[67].Add(2); leafTillerNumberArray[67].Add(3); leafTillerNumberArray[67].Add(3); leafTillerNumberArray[67].Add(3); leafTillerNumberArray[67].Add(3); leafTillerNumberArray[67].Add(3);
                leafTillerNumberArray[68].Add(1); leafTillerNumberArray[68].Add(1); leafTillerNumberArray[68].Add(1); leafTillerNumberArray[68].Add(2); leafTillerNumberArray[68].Add(3); leafTillerNumberArray[68].Add(3); leafTillerNumberArray[68].Add(3); leafTillerNumberArray[68].Add(3); leafTillerNumberArray[68].Add(3);
                #endregion

                #endregion

                #region Instantiation of other ouptuts

                //Cumulative shoot thermal time
                double cumulTTShoot = 0.0;

                int roundedFinalLeafNumber = 0;

                //Specific (photosynthetically active) Nitrogen of the Lamina
                double SpecificLaminaN = 0.0;

                bool HasNewLeafAppeared = false;

                int newLeafindex = 0;
                int newLeafLastPhytoNum = 0;

                #endregion

                #region help variables

                #region input

                //Biomass density of the leaf layer (per unit of area)
                //Value from Yecora Rojo wheat variety
                double specificWeight = 35.0;//g(DM)/m²(leaf)               

                //Daily available Nitrogen for stress factor calculation (gN/m²)
                //It is a large amount to mimic Nitrogen unlimited cultivation
                double availN = 2.5;


                #endregion

                #region intermediate

                List<LeafLayer> AllLeaves = new List<LeafLayer>();
                double previousLeafNumber = 0.0;


                #endregion

                #region Ouputs

                //Shoot Biomass
                double ShootDM = 0.0;

                //Shoot Area Index
                double ShootAI = 0.0;

                #endregion

                #endregion

                //Instantiation of a Wrapper object
                WheatLAIWrapper wheatlaiwrapper_ = new WheatLAIWrapper();

                //Loop On the day of cultivation
                for (int iday = 0; iday < stop; iday++)
                {

                    #region Calculation of other inputs for the component

                    roundedFinalLeafNumber = (int)(FinalLeafNumber[iday] + 0.5);

                    cumulTTShoot += deltaTTShoot[iday];

                    //Here a dummy estimation of the leaf specific Nitrogen of the newly created Leaf Layer
                    //It corresponds the available Nitrogen distributed among the growing leaf layers
                    double nbLayerwhitGAI = 0;
                    foreach (LeafLayer leaflayer in AllLeaves) if (leaflayer.State == LeafState.Growing) nbLayerwhitGAI++;
                    SpecificLaminaN = (availN / (nbLayerwhitGAI + 1));

                    //Estimate of the maximum GAI of the leaf layer
                    foreach (LeafLayer leaflayer in AllLeaves) leaflayer.MaxAI = Math.Max(leaflayer.MaxAI, leaflayer.GAI);

                    #endregion

                    #region Create Leaf Layer

                    if (iday - 1 >= 0) previousLeafNumber = LeafNumber[iday - 1];
                    else previousLeafNumber = 0.0;

                    HasNewLeafAppeared = false;

                    if (FinalLeafNumber[iday] > 0)
                    {
                        // final number of phytomer is known.
                        if (LeafNumber[iday] <= roundedFinalLeafNumber)
                        {
                            bool CreateOrNot = false;
                            if (LeafNumber[iday] > 0) CreateOrNot = true;

                            // a leaf Layer is growing, do nothing.
                            if (Math.Floor(previousLeafNumber) == Math.Floor(LeafNumber[iday]) && (previousLeafNumber > 0)) CreateOrNot = false;

                            if (CreateOrNot)
                            {
                                double TTatEmergence = cumulTTShoot;

                                //Create an object of the LeafLayer Class
                                AllLeaves.Add(new LeafLayer(Phyllochron[iday], SpecificLaminaN, TTatEmergence));

                                //Create a leaf layer for the component
                                wheatlaiwrapper_.CreateLeafLayerLAIComponentWheat();

                                HasNewLeafAppeared = true;
                            }
                        }
                    }
                    else
                    {
                        bool CreateOrNot = false;
                        if (LeafNumber[iday] > 0) { CreateOrNot = true; }

                        // a leaf Layer is growing, do nothing.
                        if ((Math.Floor(previousLeafNumber) == Math.Floor(LeafNumber[iday])) && (previousLeafNumber > 0)) CreateOrNot = false;

                        if (CreateOrNot)
                        {
                            double TTatEmergence = cumulTTShoot;

                            //Create an object of the LeafLayer Class
                            AllLeaves.Add(new LeafLayer(Phyllochron[iday], SpecificLaminaN, TTatEmergence));

                            //Create a leaf layer for the component
                            wheatlaiwrapper_.CreateLeafLayerLAIComponentWheat();

                            HasNewLeafAppeared = true;
                        }
                    }

                    #endregion

                    #region Calculation of other inputs for the component

                    newLeafindex = AllLeaves.Count - 1;
                    newLeafLastPhytoNum = newLeafindex + 1;

                    #endregion

                    //Call of the component
                    wheatlaiwrapper_.Estimate(HasNewLeafAppeared, roundedFinalLeafNumber, FinalLeafNumber[iday], LeafNumber[iday],
                                              newLeafLastPhytoNum, newLeafindex, FPAW[iday], false, cumulTTShoot, deltaTTShoot[iday],
                                              deltaTTSenescence[iday], AllLeaves, VPDairCanopy[iday], tilleringProfile[iday], leafTillerNumberArray[iday]);



                    #region Grow/Kill leaves

                    #region Calculate increase/deacrease in area index

                    wheatlaiwrapper_.UpdateAreas(cumulTTShoot, availN, AllLeaves);

                    #endregion

                    #region Shoot Area Index and Dry Matter dynamics

                    int ileaf = 0;

                    foreach (LeafLayer leaflayer in AllLeaves)
                    {

                        #region Shoot Area Index increase/Decrease

                        ShootAI += leaflayer.DeltaAI;

                        #endregion

                        #region bioMass Increase

                        if (leaflayer.State == LeafState.Growing)
                        {
                            leaflayer.DeltaDM = leaflayer.DeltaAI * specificWeight;
                            ShootDM += leaflayer.DeltaDM;
                        }

                        #endregion

                        #region Biomass decrease

                        if (leaflayer.State == LeafState.Senescing)
                        {
                            leaflayer.DeltaDM = leaflayer.DeltaAI * specificWeight;
                            ShootDM += leaflayer.DeltaDM;
                        }

                        #endregion

                        ileaf++;
                    }
                    #endregion

                    #endregion

                    #region Console Write

                    // Call an output of the component
                    // do wheatlaiwrapper_.My output
                    // e.g. wheatlaiwrapper_.getLeafStateList() List of the leaf layer states (Growing, Senecsing, dead...)
                    //...

                    string space = "                                  ";

                    Console.WriteLine("Day" + space.Substring(0, space.Length - 3)
                                      + "Tot GAI" + space.Substring(0, space.Length - 7)
                                      + "Tot DM" + space.Substring(0, space.Length - 7));

                    int len = space.Length;
                    string cday = iday.ToString();
                    string SAI = "";
                    if (ShootAI > 0.0) SAI = ShootAI.ToString().Substring(0, 5);
                    else SAI = ShootAI.ToString();
                    string SDM = "";
                    if (ShootDM > 0.0) SDM = ShootDM.ToString().Substring(0, 5);
                    else SDM = ShootDM.ToString();

                    Console.WriteLine(cday + space.Substring(0, len - cday.Length)
                                      + SAI + space.Substring(0, len - SAI.Length)
                                      + SDM + space.Substring(0, len - SDM.Length));

                    Console.WriteLine("Layers" + space.Substring(0, space.Length - 6)
                    + "GAI" + space.Substring(0, space.Length - 3)
                    + "State" + space.Substring(0, space.Length - 5));

                    int countlayer = 0;

                    foreach (LeafLayer leaflayer in AllLeaves)
                    {
                        countlayer++;

                        string il = countlayer.ToString();
                        string GAI = "";
                        if (leaflayer.GAI != 0) GAI = leaflayer.GAI.ToString().Substring(0, 5);
                        else GAI = leaflayer.GAI.ToString();
                        List<LeafState> LLS = wheatlaiwrapper_.getLeafStateList();
                        string S = LLS[countlayer - 1].ToString();

                        Console.WriteLine(il + space.Substring(0, len - il.Length)
                                           + GAI + space.Substring(0, len - GAI.Length)
                                           + S + space.Substring(0, len - S.Length));
                    }
                    #endregion
                }

                #region Console Write

                Console.Write("type \"C\" to continue, something else to exit");
                string brkcond = Console.ReadLine();
                if (brkcond != "C") break;

                #endregion
            }
        }
    }
}
