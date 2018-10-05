using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiriusQualityWheatLAI;
using System.Collections.Generic;

namespace UnitTestWheatLAI
{
    [TestClass]
    public class UnitTestWheatLAI
    {
        #region Instantiation

        private SiriusQualityWheatLAI.Strategies.WheatLAI wheatLAI_;
        private SiriusQualityWheatLAI.WheatLAIState wheatLaistate_;
        private SiriusQualityWheatLAI.WheatLeafState wheatLeafstate_;
        private SiriusQualityWheatLAI.WheatLeafState wheatLeafstate1_;

        #endregion

        #region Parameter Values

        double AreaPL = 27.378;
        double AreaSL = 9.0;
        double AreaSS = 1.83;
        double LowerFPAWexp = 0.1;
        double LowerFPAWsen = 0.1;
        double LowerVPD = 15.0;
        double MaxDSF = 4.5;
        double NLL = 5.69;
        double PexpL = 1.1;
        double RatioFLPL = 1.06;
        double SLNmin = 0.35;
        double UpperFPAWexp = 0.5;
        double UpperFPAWsen = 0.4;
        double UpperVPD = 45.0;
        double PlagLL = 8.0;
        double PlagSL = 4.0;
        double PsenLL = 5.0;
        double PsenSL = 3.3;

        bool isPotentialLAI = false;

        #endregion


        [TestMethod]
        public void TestMethodWheatLAI()
        {
            #region Instantiation

            wheatLAI_ = new SiriusQualityWheatLAI.Strategies.WheatLAI();
            wheatLaistate_ = new SiriusQualityWheatLAI.WheatLAIState();
            wheatLeafstate_ = new SiriusQualityWheatLAI.WheatLeafState();
            wheatLeafstate1_ = new SiriusQualityWheatLAI.WheatLeafState();
            
            #endregion

            #region Load Parameters

            wheatLAI_.AreaPL = AreaPL;
            wheatLAI_.AreaSL = AreaSL;
            wheatLAI_.AreaSS = AreaSS;
            wheatLAI_.LowerFPAWexp = LowerFPAWexp;
            wheatLAI_.LowerFPAWsen = LowerFPAWsen;
            wheatLAI_.LowerVPD = LowerVPD;
            wheatLAI_.MaxDSF = MaxDSF;
            wheatLAI_.NLL = NLL;
            wheatLAI_.PexpL = PexpL;
            wheatLAI_.RatioFLPL = RatioFLPL;
            wheatLAI_.SLNmin = SLNmin;
            wheatLAI_.UpperFPAWexp = UpperFPAWexp;
            wheatLAI_.UpperFPAWsen = UpperFPAWsen;
            wheatLAI_.UpperVPD = UpperVPD;
            wheatLAI_.PlagLL = PlagLL;
            wheatLAI_.PlagSL = PlagSL;
            wheatLAI_.PsenLL = PsenLL;
            wheatLAI_.PsenSL = PsenSL;

            #endregion

            #region Inputs

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

            int[] roundedFinalNumber = { 0,0,0,0,0,0,
                                         0,0,0,0,0,
                                         0,0,9,9,9,
                                         9,9,9,9,9,
                                         9,9,9,9,9,
                                         9,9,9,9,9,
                                         9,9,9,9,9,
                                         9,9,9,9,9,
                                         9,9,9,9,9,
                                         9,9,9,9,9,
                                         9,9,9,9,9,
                                         9,9,9,9,9,
                                         9,9,9,9,9,
                                         9,9,9};


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

            double[] cumulTTShoot = {112.330110409888,131.766338184922,144.507557859824,157.969706915664,173.501821892742,192.489500875143,
                                     213.957312379378,235.840844118137,258.149102128033,280.570678654207,292.547837558849,
                                     309.482943303315,330.422471116653,354.582294511779,378.453152853726,402.042720581446,
                                     424.98704708663,443.596560146123,467.23305195298,487.544313430698,505.964639030294,
                                     521.670687385396,541.891356128007,560.665248444002,578.86985581448,593.549779540113,
                                     611.246633341486,630.705921432785,646.389617338974,664.653055474168,683.803694384064,
                                     704.071277481929,722.16776234344,741.510096671757,763.299490579474,782.584903367456,
                                     802.789538328232,821.622646354686,839.713139783671,853.999637026622,867.497182793193,
                                     883.007176177819,898.812782230252,915.912771653277,934.881600073939,954.59002776961,
                                     972.970888983105,990.627881923557,1008.17909107202,1025.12776450052,1043.08351464284,
                                     1061.0968393348,1080.45988068211,1098.90912713933,1117.58076997323,1134.94632006267,
                                     1151.7591422971,1166.91148593622,1184.6683770075,1204.43746403522,1223.86304898068,
                                     1245.08125122249,1266.03899709772,1287.23162106791,1309.64310971569,1332.89723886722,
                                     1356.7575804833,1381.87633830872,1406.05383897947
                                    };

            bool[] HasNewLeafAppeared = {true,true,false,false,true,false,
                                         true,false,false,true,false,
                                         false,false,false,true,false,
                                         false,false,true,false,false,
                                         false,false,true,false,false,
                                         false,false,true,false,false,
                                         false,false,false,false,false,
                                         false,false,false,false,false,
                                         false,false,false,false,false,
                                         false,false,false,false,false,
                                         false,false,false,false,false,
                                         false,false,false,false,false,
                                         false,false,false,false,false,
                                         false,false,false };


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

            int[] newLeafLastPhytoNum = { 1,2,2,2,3,3,
                                          4,4,4,5,5,
                                          5,5,5,6,6,
                                          6,6,7,7,7,
                                          7,7,8,8,8,
                                          8,8,9,9,9,
                                          9,9,9,9,9,
                                          9,9,9,9,9,
                                          9,9,9,9,9,
                                          9,9,9,9,9,
                                          9,9,9,9,9,
                                          9,9,9,9,9,
                                          9,9,9,9,9,
                                          9,9,9};

            int[] newLeafindex = { 0,1,1,1,2,2,
                                   3,3,3,4,4,
                                   4,4,4,5,5,
                                   5,5,6,6,6,
                                   6,6,7,7,7,
                                   7,7,8,8,8,
                                   8,8,8,8,8,
                                   8,8,8,8,8,
                                   8,8,8,8,8,
                                   8,8,8,8,8,
                                   8,8,8,8,8,
                                   8,8,8,8,8,
                                   8,8,8,8,8,
                                   8,8,8}; 

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


            List<List<string>> LayerState = new List<List<string>>();
            #region Valorization
            LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>()); LayerState.Add(new List<string>());
            LayerState[0].Add("Growing");
            LayerState[1].Add("Growing"); LayerState[1].Add("Growing");
            LayerState[2].Add("Growing"); LayerState[2].Add("Growing");
            LayerState[3].Add("Growing"); LayerState[3].Add("Growing");
            LayerState[4].Add("Growing"); LayerState[4].Add("Growing"); LayerState[4].Add("Growing");
            LayerState[5].Add("Mature"); LayerState[5].Add("Mature"); LayerState[5].Add("Growing");
            LayerState[6].Add("Mature"); LayerState[6].Add("Mature"); LayerState[6].Add("Growing"); LayerState[6].Add("Growing");
            LayerState[7].Add("Mature"); LayerState[7].Add("Mature"); LayerState[7].Add("Mature"); LayerState[7].Add("Growing");
            LayerState[8].Add("Mature"); LayerState[8].Add("Mature"); LayerState[8].Add("Mature"); LayerState[8].Add("Growing");
            LayerState[9].Add("Senescing"); LayerState[9].Add("Senescing"); LayerState[9].Add("Mature"); LayerState[9].Add("Growing"); LayerState[9].Add("Growing");
            LayerState[10].Add("Senescing"); LayerState[10].Add("Senescing"); LayerState[10].Add("Senescing"); LayerState[10].Add("Growing"); LayerState[10].Add("Growing");
            LayerState[11].Add("Dead"); LayerState[11].Add("Dead"); LayerState[11].Add("Senescing"); LayerState[11].Add("Growing"); LayerState[11].Add("Growing");
            LayerState[12].Add("Dead"); LayerState[12].Add("Dead"); LayerState[12].Add("Dead"); LayerState[12].Add("Growing"); LayerState[12].Add("Growing");
            LayerState[13].Add("Dead"); LayerState[13].Add("Dead"); LayerState[13].Add("Dead"); LayerState[13].Add("Mature"); LayerState[13].Add("Growing");
            LayerState[14].Add("Dead"); LayerState[14].Add("Dead"); LayerState[14].Add("Dead"); LayerState[14].Add("Mature"); LayerState[14].Add("Growing"); LayerState[14].Add("Growing");
            LayerState[15].Add("Dead"); LayerState[15].Add("Dead"); LayerState[15].Add("Dead"); LayerState[15].Add("Mature"); LayerState[15].Add("Growing"); LayerState[15].Add("Growing");
            LayerState[16].Add("Dead"); LayerState[16].Add("Dead"); LayerState[16].Add("Dead"); LayerState[16].Add("Mature"); LayerState[16].Add("Mature"); LayerState[16].Add("Growing");
            LayerState[17].Add("Dead"); LayerState[17].Add("Dead"); LayerState[17].Add("Dead"); LayerState[17].Add("Mature"); LayerState[17].Add("Mature"); LayerState[17].Add("Growing");
            LayerState[18].Add("Dead"); LayerState[18].Add("Dead"); LayerState[18].Add("Dead"); LayerState[18].Add("Senescing"); LayerState[18].Add("Mature"); LayerState[18].Add("Growing"); LayerState[18].Add("Growing");
            LayerState[19].Add("Dead"); LayerState[19].Add("Dead"); LayerState[19].Add("Dead"); LayerState[19].Add("Senescing"); LayerState[19].Add("Mature"); LayerState[19].Add("Growing"); LayerState[19].Add("Growing");
            LayerState[20].Add("Dead"); LayerState[20].Add("Dead"); LayerState[20].Add("Dead"); LayerState[20].Add("Senescing"); LayerState[20].Add("Mature"); LayerState[20].Add("Growing"); LayerState[20].Add("Growing");
            LayerState[21].Add("Dead"); LayerState[21].Add("Dead"); LayerState[21].Add("Dead"); LayerState[21].Add("Senescing"); LayerState[21].Add("Mature"); LayerState[21].Add("Mature"); LayerState[21].Add("Growing");
            LayerState[22].Add("Dead"); LayerState[22].Add("Dead"); LayerState[22].Add("Dead"); LayerState[22].Add("Senescing"); LayerState[22].Add("Mature"); LayerState[22].Add("Mature"); LayerState[22].Add("Growing");
            LayerState[23].Add("Dead"); LayerState[23].Add("Dead"); LayerState[23].Add("Dead"); LayerState[23].Add("Senescing"); LayerState[23].Add("Mature"); LayerState[23].Add("Mature"); LayerState[23].Add("Growing"); LayerState[23].Add("Growing");
            LayerState[24].Add("Dead"); LayerState[24].Add("Dead"); LayerState[24].Add("Dead"); LayerState[24].Add("Senescing"); LayerState[24].Add("Mature"); LayerState[24].Add("Mature"); LayerState[24].Add("Growing"); LayerState[24].Add("Growing");
            LayerState[25].Add("Dead"); LayerState[25].Add("Dead"); LayerState[25].Add("Dead"); LayerState[25].Add("Senescing"); LayerState[25].Add("Mature"); LayerState[25].Add("Mature"); LayerState[25].Add("Growing"); LayerState[25].Add("Growing");
            LayerState[26].Add("Dead"); LayerState[26].Add("Dead"); LayerState[26].Add("Dead"); LayerState[26].Add("Dead"); LayerState[26].Add("Senescing"); LayerState[26].Add("Mature"); LayerState[26].Add("Growing"); LayerState[26].Add("Growing");
            LayerState[27].Add("Dead"); LayerState[27].Add("Dead"); LayerState[27].Add("Dead"); LayerState[27].Add("Dead"); LayerState[27].Add("Senescing"); LayerState[27].Add("Mature"); LayerState[27].Add("Growing"); LayerState[27].Add("Growing");
            LayerState[28].Add("Dead"); LayerState[28].Add("Dead"); LayerState[28].Add("Dead"); LayerState[28].Add("Dead"); LayerState[28].Add("Senescing"); LayerState[28].Add("Mature"); LayerState[28].Add("Mature"); LayerState[28].Add("Growing"); LayerState[28].Add("Growing");
            LayerState[29].Add("Dead"); LayerState[29].Add("Dead"); LayerState[29].Add("Dead"); LayerState[29].Add("Dead"); LayerState[29].Add("Senescing"); LayerState[29].Add("Mature"); LayerState[29].Add("Mature"); LayerState[29].Add("Growing"); LayerState[29].Add("Growing");
            LayerState[30].Add("Dead"); LayerState[30].Add("Dead"); LayerState[30].Add("Dead"); LayerState[30].Add("Dead"); LayerState[30].Add("Senescing"); LayerState[30].Add("Mature"); LayerState[30].Add("Mature"); LayerState[30].Add("Growing"); LayerState[30].Add("Growing");
            LayerState[31].Add("Dead"); LayerState[31].Add("Dead"); LayerState[31].Add("Dead"); LayerState[31].Add("Dead"); LayerState[31].Add("Senescing"); LayerState[31].Add("Mature"); LayerState[31].Add("Mature"); LayerState[31].Add("Growing"); LayerState[31].Add("Growing");
            LayerState[32].Add("Dead"); LayerState[32].Add("Dead"); LayerState[32].Add("Dead"); LayerState[32].Add("Dead"); LayerState[32].Add("Senescing"); LayerState[32].Add("Mature"); LayerState[32].Add("Mature"); LayerState[32].Add("Growing"); LayerState[32].Add("Growing");
            LayerState[33].Add("Dead"); LayerState[33].Add("Dead"); LayerState[33].Add("Dead"); LayerState[33].Add("Dead"); LayerState[33].Add("Senescing"); LayerState[33].Add("Mature"); LayerState[33].Add("Mature"); LayerState[33].Add("Growing"); LayerState[33].Add("Growing");
            LayerState[34].Add("Dead"); LayerState[34].Add("Dead"); LayerState[34].Add("Dead"); LayerState[34].Add("Dead"); LayerState[34].Add("Senescing"); LayerState[34].Add("Mature"); LayerState[34].Add("Mature"); LayerState[34].Add("Mature"); LayerState[34].Add("Growing");
            LayerState[35].Add("Dead"); LayerState[35].Add("Dead"); LayerState[35].Add("Dead"); LayerState[35].Add("Dead"); LayerState[35].Add("Senescing"); LayerState[35].Add("Mature"); LayerState[35].Add("Mature"); LayerState[35].Add("Mature"); LayerState[35].Add("Growing");
            LayerState[36].Add("Dead"); LayerState[36].Add("Dead"); LayerState[36].Add("Dead"); LayerState[36].Add("Dead"); LayerState[36].Add("Dead"); LayerState[36].Add("Mature"); LayerState[36].Add("Mature"); LayerState[36].Add("Mature"); LayerState[36].Add("Growing");
            LayerState[37].Add("Dead"); LayerState[37].Add("Dead"); LayerState[37].Add("Dead"); LayerState[37].Add("Dead"); LayerState[37].Add("Dead"); LayerState[37].Add("Mature"); LayerState[37].Add("Mature"); LayerState[37].Add("Mature"); LayerState[37].Add("Growing");
            LayerState[38].Add("Dead"); LayerState[38].Add("Dead"); LayerState[38].Add("Dead"); LayerState[38].Add("Dead"); LayerState[38].Add("Dead"); LayerState[38].Add("Mature"); LayerState[38].Add("Mature"); LayerState[38].Add("Mature"); LayerState[38].Add("Growing");
            LayerState[39].Add("Dead"); LayerState[39].Add("Dead"); LayerState[39].Add("Dead"); LayerState[39].Add("Dead"); LayerState[39].Add("Dead"); LayerState[39].Add("Mature"); LayerState[39].Add("Mature"); LayerState[39].Add("Mature"); LayerState[39].Add("Growing");
            LayerState[40].Add("Dead"); LayerState[40].Add("Dead"); LayerState[40].Add("Dead"); LayerState[40].Add("Dead"); LayerState[40].Add("Dead"); LayerState[40].Add("Mature"); LayerState[40].Add("Mature"); LayerState[40].Add("Mature"); LayerState[40].Add("Growing");
            LayerState[41].Add("Dead"); LayerState[41].Add("Dead"); LayerState[41].Add("Dead"); LayerState[41].Add("Dead"); LayerState[41].Add("Dead"); LayerState[41].Add("Mature"); LayerState[41].Add("Mature"); LayerState[41].Add("Mature"); LayerState[41].Add("Growing");
            LayerState[42].Add("Dead"); LayerState[42].Add("Dead"); LayerState[42].Add("Dead"); LayerState[42].Add("Dead"); LayerState[42].Add("Dead"); LayerState[42].Add("Mature"); LayerState[42].Add("Mature"); LayerState[42].Add("Mature"); LayerState[42].Add("Growing");
            LayerState[43].Add("Dead"); LayerState[43].Add("Dead"); LayerState[43].Add("Dead"); LayerState[43].Add("Dead"); LayerState[43].Add("Dead"); LayerState[43].Add("Mature"); LayerState[43].Add("Mature"); LayerState[43].Add("Mature"); LayerState[43].Add("Mature");
            LayerState[44].Add("Dead"); LayerState[44].Add("Dead"); LayerState[44].Add("Dead"); LayerState[44].Add("Dead"); LayerState[44].Add("Dead"); LayerState[44].Add("Mature"); LayerState[44].Add("Mature"); LayerState[44].Add("Mature"); LayerState[44].Add("Mature");
            LayerState[45].Add("Dead"); LayerState[45].Add("Dead"); LayerState[45].Add("Dead"); LayerState[45].Add("Dead"); LayerState[45].Add("Dead"); LayerState[45].Add("Mature"); LayerState[45].Add("Mature"); LayerState[45].Add("Mature"); LayerState[45].Add("Mature");
            LayerState[46].Add("Dead"); LayerState[46].Add("Dead"); LayerState[46].Add("Dead"); LayerState[46].Add("Dead"); LayerState[46].Add("Dead"); LayerState[46].Add("Mature"); LayerState[46].Add("Mature"); LayerState[46].Add("Mature"); LayerState[46].Add("Mature");
            LayerState[47].Add("Dead"); LayerState[47].Add("Dead"); LayerState[47].Add("Dead"); LayerState[47].Add("Dead"); LayerState[47].Add("Dead"); LayerState[47].Add("Mature"); LayerState[47].Add("Mature"); LayerState[47].Add("Mature"); LayerState[47].Add("Mature");
            LayerState[48].Add("Dead"); LayerState[48].Add("Dead"); LayerState[48].Add("Dead"); LayerState[48].Add("Dead"); LayerState[48].Add("Dead"); LayerState[48].Add("Mature"); LayerState[48].Add("Mature"); LayerState[48].Add("Mature"); LayerState[48].Add("Mature");
            LayerState[49].Add("Dead"); LayerState[49].Add("Dead"); LayerState[49].Add("Dead"); LayerState[49].Add("Dead"); LayerState[49].Add("Dead"); LayerState[49].Add("Mature"); LayerState[49].Add("Mature"); LayerState[49].Add("Mature"); LayerState[49].Add("Mature");
            LayerState[50].Add("Dead"); LayerState[50].Add("Dead"); LayerState[50].Add("Dead"); LayerState[50].Add("Dead"); LayerState[50].Add("Dead"); LayerState[50].Add("Senescing"); LayerState[50].Add("Mature"); LayerState[50].Add("Mature"); LayerState[50].Add("Mature");
            LayerState[51].Add("Dead"); LayerState[51].Add("Dead"); LayerState[51].Add("Dead"); LayerState[51].Add("Dead"); LayerState[51].Add("Dead"); LayerState[51].Add("Senescing"); LayerState[51].Add("Mature"); LayerState[51].Add("Mature"); LayerState[51].Add("Mature");
            LayerState[52].Add("Dead"); LayerState[52].Add("Dead"); LayerState[52].Add("Dead"); LayerState[52].Add("Dead"); LayerState[52].Add("Dead"); LayerState[52].Add("Senescing"); LayerState[52].Add("Mature"); LayerState[52].Add("Mature"); LayerState[52].Add("Mature");
            LayerState[53].Add("Dead"); LayerState[53].Add("Dead"); LayerState[53].Add("Dead"); LayerState[53].Add("Dead"); LayerState[53].Add("Dead"); LayerState[53].Add("Senescing"); LayerState[53].Add("Mature"); LayerState[53].Add("Mature"); LayerState[53].Add("Mature");
            LayerState[54].Add("Dead"); LayerState[54].Add("Dead"); LayerState[54].Add("Dead"); LayerState[54].Add("Dead"); LayerState[54].Add("Dead"); LayerState[54].Add("Senescing"); LayerState[54].Add("Senescing"); LayerState[54].Add("Mature"); LayerState[54].Add("Mature");
            LayerState[55].Add("Dead"); LayerState[55].Add("Dead"); LayerState[55].Add("Dead"); LayerState[55].Add("Dead"); LayerState[55].Add("Dead"); LayerState[55].Add("Senescing"); LayerState[55].Add("Senescing"); LayerState[55].Add("Mature"); LayerState[55].Add("Mature");
            LayerState[56].Add("Dead"); LayerState[56].Add("Dead"); LayerState[56].Add("Dead"); LayerState[56].Add("Dead"); LayerState[56].Add("Dead"); LayerState[56].Add("Senescing"); LayerState[56].Add("Senescing"); LayerState[56].Add("Mature"); LayerState[56].Add("Mature");
            LayerState[57].Add("Dead"); LayerState[57].Add("Dead"); LayerState[57].Add("Dead"); LayerState[57].Add("Dead"); LayerState[57].Add("Dead"); LayerState[57].Add("Senescing"); LayerState[57].Add("Senescing"); LayerState[57].Add("Mature"); LayerState[57].Add("Mature");
            LayerState[58].Add("Dead"); LayerState[58].Add("Dead"); LayerState[58].Add("Dead"); LayerState[58].Add("Dead"); LayerState[58].Add("Dead"); LayerState[58].Add("Senescing"); LayerState[58].Add("Senescing"); LayerState[58].Add("Mature"); LayerState[58].Add("Mature");
            LayerState[59].Add("Dead"); LayerState[59].Add("Dead"); LayerState[59].Add("Dead"); LayerState[59].Add("Dead"); LayerState[59].Add("Dead"); LayerState[59].Add("Senescing"); LayerState[59].Add("Senescing"); LayerState[59].Add("Mature"); LayerState[59].Add("Mature");
            LayerState[60].Add("Dead"); LayerState[60].Add("Dead"); LayerState[60].Add("Dead"); LayerState[60].Add("Dead"); LayerState[60].Add("Dead"); LayerState[60].Add("Dead"); LayerState[60].Add("Senescing"); LayerState[60].Add("Senescing"); LayerState[60].Add("Mature");
            LayerState[61].Add("Dead"); LayerState[61].Add("Dead"); LayerState[61].Add("Dead"); LayerState[61].Add("Dead"); LayerState[61].Add("Dead"); LayerState[61].Add("Dead"); LayerState[61].Add("Senescing"); LayerState[61].Add("Senescing"); LayerState[61].Add("Mature");
            LayerState[62].Add("Dead"); LayerState[62].Add("Dead"); LayerState[62].Add("Dead"); LayerState[62].Add("Dead"); LayerState[62].Add("Dead"); LayerState[62].Add("Dead"); LayerState[62].Add("Senescing"); LayerState[62].Add("Senescing"); LayerState[62].Add("Mature");
            LayerState[63].Add("Dead"); LayerState[63].Add("Dead"); LayerState[63].Add("Dead"); LayerState[63].Add("Dead"); LayerState[63].Add("Dead"); LayerState[63].Add("Dead"); LayerState[63].Add("Senescing"); LayerState[63].Add("Senescing"); LayerState[63].Add("Mature");
            LayerState[64].Add("Dead"); LayerState[64].Add("Dead"); LayerState[64].Add("Dead"); LayerState[64].Add("Dead"); LayerState[64].Add("Dead"); LayerState[64].Add("Dead"); LayerState[64].Add("Dead"); LayerState[64].Add("Senescing"); LayerState[64].Add("Mature");
            LayerState[65].Add("Dead"); LayerState[65].Add("Dead"); LayerState[65].Add("Dead"); LayerState[65].Add("Dead"); LayerState[65].Add("Dead"); LayerState[65].Add("Dead"); LayerState[65].Add("Dead"); LayerState[65].Add("Senescing"); LayerState[65].Add("Mature");
            LayerState[66].Add("Dead"); LayerState[66].Add("Dead"); LayerState[66].Add("Dead"); LayerState[66].Add("Dead"); LayerState[66].Add("Dead"); LayerState[66].Add("Dead"); LayerState[66].Add("Dead"); LayerState[66].Add("Senescing"); LayerState[66].Add("Senescing");
            LayerState[67].Add("Dead"); LayerState[67].Add("Dead"); LayerState[67].Add("Dead"); LayerState[67].Add("Dead"); LayerState[67].Add("Dead"); LayerState[67].Add("Dead"); LayerState[67].Add("Dead"); LayerState[67].Add("Dead"); LayerState[67].Add("Senescing");
            LayerState[68].Add("Dead"); LayerState[68].Add("Dead"); LayerState[68].Add("Dead"); LayerState[68].Add("Dead"); LayerState[68].Add("Dead"); LayerState[68].Add("Dead"); LayerState[68].Add("Dead"); LayerState[68].Add("Dead"); LayerState[68].Add("Senescing");
            #endregion


            List<List<double>> GAI = new List<List<double>>();
            #region Valorization
            GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>()); GAI.Add(new List<double>());
            GAI[0].Add(0);
            GAI[1].Add(0); GAI[1].Add(0);
            GAI[2].Add(0.0153846153846154); GAI[2].Add(0.0153846153846154);
            GAI[3].Add(0.0307692307692308); GAI[3].Add(0.0307692307692308);
            GAI[4].Add(0.0345155980033622); GAI[4].Add(0.0369503717072201); GAI[4].Add(0);
            GAI[5].Add(0.0345155980033622); GAI[5].Add(0.0369503717072201); GAI[5].Add(0.0231959654021323);
            GAI[6].Add(0.03300050567272); GAI[6].Add(0.0353284028575849); GAI[6].Add(0.0598500499687857); GAI[6].Add(0);
            GAI[7].Add(0.0315442030770731); GAI[7].Add(0.033769370844809); GAI[7].Add(0.0598500499687857); GAI[7].Add(0.0491047154099971);
            GAI[8].Add(0.0315442030770731); GAI[8].Add(0.033769370844809); GAI[8].Add(0.0598500499687857); GAI[8].Add(0.101495570552927);
            GAI[9].Add(0.00897677817591268); GAI[9].Add(0.00961001140124891); GAI[9].Add(0.0598500499687857); GAI[9].Add(0.135302875735953); GAI[9].Add(0);
            GAI[10].Add(0); GAI[10].Add(0); GAI[10].Add(0.0257220079373397); GAI[10].Add(0.193514780650013); GAI[10].Add(0.0606374009521458);
            GAI[11].Add(0); GAI[11].Add(0); GAI[11].Add(0); GAI[11].Add(0.228470264851486); GAI[11].Add(0.0970493636620139);
            GAI[12].Add(0); GAI[12].Add(0); GAI[12].Add(0); GAI[12].Add(0.228470264851486); GAI[12].Add(0.0970493636620139);
            GAI[13].Add(0); GAI[13].Add(0); GAI[13].Add(0); GAI[13].Add(0.228470264851486); GAI[13].Add(0.0970493636620139);
            GAI[14].Add(0); GAI[14].Add(0); GAI[14].Add(0); GAI[14].Add(0.228470264851486); GAI[14].Add(0.129525670978161); GAI[14].Add(0);
            GAI[15].Add(0); GAI[15].Add(0); GAI[15].Add(0); GAI[15].Add(0.228470264851486); GAI[15].Add(0.194791647193763); GAI[15].Add(0.105492417126326);
            GAI[16].Add(0); GAI[16].Add(0); GAI[16].Add(0); GAI[16].Add(0.228470264851486); GAI[16].Add(0.194791647193763); GAI[16].Add(0.208654236643407);
            GAI[17].Add(0); GAI[17].Add(0); GAI[17].Add(0); GAI[17].Add(0.228470264851486); GAI[17].Add(0.194791647193763); GAI[17].Add(0.342938664232987);
            GAI[18].Add(0); GAI[18].Add(0); GAI[18].Add(0); GAI[18].Add(0.199867416288524); GAI[18].Add(0.194791647193763); GAI[18].Add(0.455017706812656); GAI[18].Add(0);
            GAI[19].Add(0); GAI[19].Add(0); GAI[19].Add(0); GAI[19].Add(0.171403514909515); GAI[19].Add(0.186585829174297); GAI[19].Add(0.582077519733937); GAI[19].Add(0.178046896758072);
            GAI[20].Add(0); GAI[20].Add(0); GAI[20].Add(0); GAI[20].Add(0.120269542267178); GAI[20].Add(0.186585829174297); GAI[20].Add(0.675483676240548); GAI[20].Add(0.308935459567497);
            GAI[21].Add(0); GAI[21].Add(0); GAI[21].Add(0); GAI[21].Add(0.0844500077944501); GAI[21].Add(0.186585829174297); GAI[21].Add(0.675483676240548); GAI[21].Add(0.426781637945857);
            GAI[22].Add(0); GAI[22].Add(0); GAI[22].Add(0); GAI[22].Add(0.0725894471466019); GAI[22].Add(0.186585829174297); GAI[22].Add(0.675483676240548); GAI[22].Add(0.618143091158726);
            GAI[23].Add(0); GAI[23].Add(0); GAI[23].Add(0); GAI[23].Add(0.0565322379158223); GAI[23].Add(0.186585829174297); GAI[23].Add(0.675483676240548); GAI[23].Add(0.86466887761935); GAI[23].Add(0);
            GAI[24].Add(0); GAI[24].Add(0); GAI[24].Add(0); GAI[24].Add(0.0244392392492377); GAI[24].Add(0.179399669474361); GAI[24].Add(0.653065564248542); GAI[24].Add(1.02506569169063); GAI[24].Add(0.20632946414897);
            GAI[25].Add(0); GAI[25].Add(0); GAI[25].Add(0); GAI[25].Add(0); GAI[25].Add(0.172517037575482); GAI[25].Add(0.628010836457092); GAI[25].Add(1.18140570356758); GAI[25].Add(0.407440384352653);
            GAI[26].Add(0); GAI[26].Add(0); GAI[26].Add(0); GAI[26].Add(0); GAI[26].Add(0.153049529701459); GAI[26].Add(0.614027680728081); GAI[26].Add(1.32828216772821); GAI[26].Add(0.596377691629149);
            GAI[27].Add(0); GAI[27].Add(0); GAI[27].Add(0); GAI[27].Add(0); GAI[27].Add(0.136008393080976); GAI[27].Add(0.589873408357345); GAI[27].Add(1.4835422259211); GAI[27].Add(0.796099393061705);
            GAI[28].Add(0); GAI[28].Add(0); GAI[28].Add(0); GAI[28].Add(0); GAI[28].Add(0.123061541462962); GAI[28].Add(0.588835187953389); GAI[28].Add(1.4835422259211); GAI[28].Add(1.10128166280763); GAI[28].Add(0);
            GAI[29].Add(0); GAI[29].Add(0); GAI[29].Add(0); GAI[29].Add(0); GAI[29].Add(0.10321708345581); GAI[29].Add(0.571562304949146); GAI[29].Add(1.44002401942727); GAI[29].Add(1.30423794973146); GAI[29].Add(0.172106931311405);
            GAI[30].Add(0); GAI[30].Add(0); GAI[30].Add(0); GAI[30].Add(0); GAI[30].Add(0.0871738270213379); GAI[30].Add(0.547613127427503); GAI[30].Add(1.3796852067063); GAI[30].Add(1.53797724579889); GAI[30].Add(0.370317854376584);
            GAI[31].Add(0); GAI[31].Add(0); GAI[31].Add(0); GAI[31].Add(0); GAI[31].Add(0.0671555206455785); GAI[31].Add(0.525426067927696); GAI[31].Add(1.32378596645982); GAI[31].Add(1.76625024971234); GAI[31].Add(0.563893361695193);
            GAI[32].Add(0); GAI[32].Add(0); GAI[32].Add(0); GAI[32].Add(0); GAI[32].Add(0.0432952156957241); GAI[32].Add(0.504936478195626); GAI[32].Add(1.27216342048906); GAI[32].Add(1.99051241251816); GAI[32].Add(0.754067675754529);
            GAI[33].Add(0); GAI[33].Add(0); GAI[33].Add(0); GAI[33].Add(0); GAI[33].Add(0.0214865182431199); GAI[33].Add(0.483987333607049); GAI[33].Add(1.21938304793337); GAI[33].Add(2.21478607330034); GAI[33].Add(0.944251740097817);
            GAI[34].Add(0); GAI[34].Add(0); GAI[34].Add(0); GAI[34].Add(0); GAI[34].Add(0.00257435376509544); GAI[34].Add(0.483987333607049); GAI[34].Add(1.21938304793337); GAI[34].Add(2.21478607330034); GAI[34].Add(1.16693961251959);
            GAI[35].Add(0); GAI[35].Add(0); GAI[35].Add(0); GAI[35].Add(0); GAI[35].Add(0); GAI[35].Add(0.483987333607049); GAI[35].Add(1.21938304793337); GAI[35].Add(2.21478607330034); GAI[35].Add(1.42904767822622);
            GAI[36].Add(0); GAI[36].Add(0); GAI[36].Add(0); GAI[36].Add(0); GAI[36].Add(0); GAI[36].Add(0.483987333607049); GAI[36].Add(1.21938304793337); GAI[36].Add(2.21478607330034); GAI[36].Add(1.64389352643251);
            GAI[37].Add(0); GAI[37].Add(0); GAI[37].Add(0); GAI[37].Add(0); GAI[37].Add(0); GAI[37].Add(0.483987333607049); GAI[37].Add(1.21938304793337); GAI[37].Add(2.21478607330034); GAI[37].Add(1.89294841222001);
            GAI[38].Add(0); GAI[38].Add(0); GAI[38].Add(0); GAI[38].Add(0); GAI[38].Add(0); GAI[38].Add(0.483987333607049); GAI[38].Add(1.21938304793337); GAI[38].Add(2.21478607330034); GAI[38].Add(2.14099565525922);
            GAI[39].Add(0); GAI[39].Add(0); GAI[39].Add(0); GAI[39].Add(0); GAI[39].Add(0); GAI[39].Add(0.483987333607049); GAI[39].Add(1.21938304793337); GAI[39].Add(2.21478607330034); GAI[39].Add(2.34955241068224);
            GAI[40].Add(0); GAI[40].Add(0); GAI[40].Add(0); GAI[40].Add(0); GAI[40].Add(0); GAI[40].Add(0.483987333607049); GAI[40].Add(1.21938304793337); GAI[40].Add(2.21478607330034); GAI[40].Add(2.53634413569602);
            GAI[41].Add(0); GAI[41].Add(0); GAI[41].Add(0); GAI[41].Add(0); GAI[41].Add(0); GAI[41].Add(0.483987333607049); GAI[41].Add(1.21938304793337); GAI[41].Add(2.21478607330034); GAI[41].Add(2.71585180655173);
            GAI[42].Add(0); GAI[42].Add(0); GAI[42].Add(0); GAI[42].Add(0); GAI[42].Add(0); GAI[42].Add(0.483987333607049); GAI[42].Add(1.21938304793337); GAI[42].Add(2.21478607330034); GAI[42].Add(2.92212358629684);
            GAI[43].Add(0); GAI[43].Add(0); GAI[43].Add(0); GAI[43].Add(0); GAI[43].Add(0); GAI[43].Add(0.483987333607049); GAI[43].Add(1.21938304793337); GAI[43].Add(2.21478607330034); GAI[43].Add(2.92212358629684);
            GAI[44].Add(0); GAI[44].Add(0); GAI[44].Add(0); GAI[44].Add(0); GAI[44].Add(0); GAI[44].Add(0.483987333607049); GAI[44].Add(1.21938304793337); GAI[44].Add(2.21478607330034); GAI[44].Add(2.92212358629684);
            GAI[45].Add(0); GAI[45].Add(0); GAI[45].Add(0); GAI[45].Add(0); GAI[45].Add(0); GAI[45].Add(0.483987333607049); GAI[45].Add(1.21938304793337); GAI[45].Add(2.21478607330034); GAI[45].Add(2.92212358629684);
            GAI[46].Add(0); GAI[46].Add(0); GAI[46].Add(0); GAI[46].Add(0); GAI[46].Add(0); GAI[46].Add(0.483987333607049); GAI[46].Add(1.21938304793337); GAI[46].Add(2.21478607330034); GAI[46].Add(2.92212358629684);
            GAI[47].Add(0); GAI[47].Add(0); GAI[47].Add(0); GAI[47].Add(0); GAI[47].Add(0); GAI[47].Add(0.483987333607049); GAI[47].Add(1.21938304793337); GAI[47].Add(2.21478607330034); GAI[47].Add(2.92212358629684);
            GAI[48].Add(0); GAI[48].Add(0); GAI[48].Add(0); GAI[48].Add(0); GAI[48].Add(0); GAI[48].Add(0.483987333607049); GAI[48].Add(1.21938304793337); GAI[48].Add(2.21478607330034); GAI[48].Add(2.92212358629684);
            GAI[49].Add(0); GAI[49].Add(0); GAI[49].Add(0); GAI[49].Add(0); GAI[49].Add(0); GAI[49].Add(0.483987333607049); GAI[49].Add(1.21938304793337); GAI[49].Add(2.21478607330034); GAI[49].Add(2.92212358629684);
            GAI[50].Add(0); GAI[50].Add(0); GAI[50].Add(0); GAI[50].Add(0); GAI[50].Add(0); GAI[50].Add(0.427706107924828); GAI[50].Add(1.21938304793337); GAI[50].Add(2.21478607330034); GAI[50].Add(2.92212358629684);
            GAI[51].Add(0); GAI[51].Add(0); GAI[51].Add(0); GAI[51].Add(0); GAI[51].Add(0); GAI[51].Add(0.382093793748523); GAI[51].Add(1.21938304793337); GAI[51].Add(2.21478607330034); GAI[51].Add(2.92212358629684);
            GAI[52].Add(0); GAI[52].Add(0); GAI[52].Add(0); GAI[52].Add(0); GAI[52].Add(0); GAI[52].Add(0.333840215202741); GAI[52].Add(1.21938304793337); GAI[52].Add(2.21478607330034); GAI[52].Add(2.92212358629684);
            GAI[53].Add(0); GAI[53].Add(0); GAI[53].Add(0); GAI[53].Add(0); GAI[53].Add(0); GAI[53].Add(0.290899114223175); GAI[53].Add(1.21938304793337); GAI[53].Add(2.21478607330034); GAI[53].Add(2.92212358629684);
            GAI[54].Add(0); GAI[54].Add(0); GAI[54].Add(0); GAI[54].Add(0); GAI[54].Add(0); GAI[54].Add(0.228734844928367); GAI[54].Add(1.08026409101104); GAI[54].Add(2.21478607330034); GAI[54].Add(2.92212358629684);
            GAI[55].Add(0); GAI[55].Add(0); GAI[55].Add(0); GAI[55].Add(0); GAI[55].Add(0); GAI[55].Add(0.169579276269188); GAI[55].Add(0.93701818465545); GAI[55].Add(2.21478607330034); GAI[55].Add(2.92212358629684);
            GAI[56].Add(0); GAI[56].Add(0); GAI[56].Add(0); GAI[56].Add(0); GAI[56].Add(0); GAI[56].Add(0.108907654728496); GAI[56].Add(0.788456240714565); GAI[56].Add(2.19009271168669); GAI[56].Add(2.92212358629684);
            GAI[57].Add(0); GAI[57].Add(0); GAI[57].Add(0); GAI[57].Add(0); GAI[57].Add(0); GAI[57].Add(0.0604448552392309); GAI[57].Add(0.6632534863598); GAI[57].Add(2.15982771845887); GAI[57].Add(2.92212358629684);
            GAI[58].Add(0); GAI[58].Add(0); GAI[58].Add(0); GAI[58].Add(0); GAI[58].Add(0); GAI[58].Add(0.0250907268992681); GAI[58].Add(0.56592783917581); GAI[58].Add(2.1280901940812); GAI[58].Add(2.92212358629684);
            GAI[59].Add(0); GAI[59].Add(0); GAI[59].Add(0); GAI[59].Add(0); GAI[59].Add(0); GAI[59].Add(0); GAI[59].Add(0.477496471103702); GAI[59].Add(2.03441551572962); GAI[59].Add(2.92212358629684);
            GAI[60].Add(0); GAI[60].Add(0); GAI[60].Add(0); GAI[60].Add(0); GAI[60].Add(0); GAI[60].Add(0); GAI[60].Add(0.357777036373534); GAI[60].Add(1.79830595572054); GAI[60].Add(2.92212358629684);
            GAI[61].Add(0); GAI[61].Add(0); GAI[61].Add(0); GAI[61].Add(0); GAI[61].Add(0); GAI[61].Add(0); GAI[61].Add(0.210620733986324); GAI[61].Add(1.52667496580142); GAI[61].Add(2.92212358629684);
            GAI[62].Add(0); GAI[62].Add(0); GAI[62].Add(0); GAI[62].Add(0); GAI[62].Add(0); GAI[62].Add(0); GAI[62].Add(0.0533888175049363); GAI[62].Add(1.2357981387703); GAI[62].Add(2.92212358629684);
            GAI[63].Add(0); GAI[63].Add(0); GAI[63].Add(0); GAI[63].Add(0); GAI[63].Add(0); GAI[63].Add(0); GAI[63].Add(0); GAI[63].Add(0.911346421232627); GAI[63].Add(2.92212358629684);
            GAI[64].Add(0); GAI[64].Add(0); GAI[64].Add(0); GAI[64].Add(0); GAI[64].Add(0); GAI[64].Add(0); GAI[64].Add(0); GAI[64].Add(0.562232761078397); GAI[64].Add(2.92212358629684);
            GAI[65].Add(0); GAI[65].Add(0); GAI[65].Add(0); GAI[65].Add(0); GAI[65].Add(0); GAI[65].Add(0); GAI[65].Add(0); GAI[65].Add(0.204171072683324); GAI[65].Add(2.84775427445061);
            GAI[66].Add(0); GAI[66].Add(0); GAI[66].Add(0); GAI[66].Add(0); GAI[66].Add(0); GAI[66].Add(0); GAI[66].Add(0); GAI[66].Add(0); GAI[66].Add(2.27264246432683);
            GAI[67].Add(0); GAI[67].Add(0); GAI[67].Add(0); GAI[67].Add(0); GAI[67].Add(0); GAI[67].Add(0); GAI[67].Add(0); GAI[67].Add(0); GAI[67].Add(1.43767690833115);
            GAI[68].Add(0); GAI[68].Add(0); GAI[68].Add(0); GAI[68].Add(0); GAI[68].Add(0); GAI[68].Add(0); GAI[68].Add(0); GAI[68].Add(0); GAI[68].Add(0.329043835030131);
            #endregion

            List<List<double>> MaxAI = new List<List<double>>();
            #region Valorization
            MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>()); MaxAI.Add(new List<double>());
            MaxAI[0].Add(0);
            MaxAI[1].Add(0); MaxAI[1].Add(0);
            MaxAI[2].Add(0.0153846153846154); MaxAI[2].Add(0.0153846153846154);
            MaxAI[3].Add(0.0307692307692308); MaxAI[3].Add(0.0307692307692308);
            MaxAI[4].Add(0.0345155980033622); MaxAI[4].Add(0.0369503717072201); MaxAI[4].Add(0);
            MaxAI[5].Add(0.0345155980033622); MaxAI[5].Add(0.0369503717072201); MaxAI[5].Add(0.0231959654021323);
            MaxAI[6].Add(0.0345155980033622); MaxAI[6].Add(0.0369503717072201); MaxAI[6].Add(0.0598500499687857); MaxAI[6].Add(0);
            MaxAI[7].Add(0.0345155980033622); MaxAI[7].Add(0.0369503717072201); MaxAI[7].Add(0.0598500499687857); MaxAI[7].Add(0.0491047154099971);
            MaxAI[8].Add(0.0345155980033622); MaxAI[8].Add(0.0369503717072201); MaxAI[8].Add(0.0598500499687857); MaxAI[8].Add(0.101495570552927);
            MaxAI[9].Add(0.0345155980033622); MaxAI[9].Add(0.0369503717072201); MaxAI[9].Add(0.0598500499687857); MaxAI[9].Add(0.135302875735953); MaxAI[9].Add(0);
            MaxAI[10].Add(0.0345155980033622); MaxAI[10].Add(0.0369503717072201); MaxAI[10].Add(0.0598500499687857); MaxAI[10].Add(0.193514780650013); MaxAI[10].Add(0.0606374009521458);
            MaxAI[11].Add(0.0345155980033622); MaxAI[11].Add(0.0369503717072201); MaxAI[11].Add(0.0598500499687857); MaxAI[11].Add(0.228470264851486); MaxAI[11].Add(0.0970493636620139);
            MaxAI[12].Add(0.0345155980033622); MaxAI[12].Add(0.0369503717072201); MaxAI[12].Add(0.0598500499687857); MaxAI[12].Add(0.228470264851486); MaxAI[12].Add(0.0970493636620139);
            MaxAI[13].Add(0.0345155980033622); MaxAI[13].Add(0.0369503717072201); MaxAI[13].Add(0.0598500499687857); MaxAI[13].Add(0.228470264851486); MaxAI[13].Add(0.0970493636620139);
            MaxAI[14].Add(0.0345155980033622); MaxAI[14].Add(0.0369503717072201); MaxAI[14].Add(0.0598500499687857); MaxAI[14].Add(0.228470264851486); MaxAI[14].Add(0.129525670978161); MaxAI[14].Add(0);
            MaxAI[15].Add(0.0345155980033622); MaxAI[15].Add(0.0369503717072201); MaxAI[15].Add(0.0598500499687857); MaxAI[15].Add(0.228470264851486); MaxAI[15].Add(0.194791647193763); MaxAI[15].Add(0.105492417126326);
            MaxAI[16].Add(0.0345155980033622); MaxAI[16].Add(0.0369503717072201); MaxAI[16].Add(0.0598500499687857); MaxAI[16].Add(0.228470264851486); MaxAI[16].Add(0.194791647193763); MaxAI[16].Add(0.208654236643407);
            MaxAI[17].Add(0.0345155980033622); MaxAI[17].Add(0.0369503717072201); MaxAI[17].Add(0.0598500499687857); MaxAI[17].Add(0.228470264851486); MaxAI[17].Add(0.194791647193763); MaxAI[17].Add(0.342938664232987);
            MaxAI[18].Add(0.0345155980033622); MaxAI[18].Add(0.0369503717072201); MaxAI[18].Add(0.0598500499687857); MaxAI[18].Add(0.228470264851486); MaxAI[18].Add(0.194791647193763); MaxAI[18].Add(0.455017706812656); MaxAI[18].Add(0);
            MaxAI[19].Add(0.0345155980033622); MaxAI[19].Add(0.0369503717072201); MaxAI[19].Add(0.0598500499687857); MaxAI[19].Add(0.228470264851486); MaxAI[19].Add(0.194791647193763); MaxAI[19].Add(0.582077519733937); MaxAI[19].Add(0.178046896758072);
            MaxAI[20].Add(0.0345155980033622); MaxAI[20].Add(0.0369503717072201); MaxAI[20].Add(0.0598500499687857); MaxAI[20].Add(0.228470264851486); MaxAI[20].Add(0.194791647193763); MaxAI[20].Add(0.675483676240548); MaxAI[20].Add(0.308935459567497);
            MaxAI[21].Add(0.0345155980033622); MaxAI[21].Add(0.0369503717072201); MaxAI[21].Add(0.0598500499687857); MaxAI[21].Add(0.228470264851486); MaxAI[21].Add(0.194791647193763); MaxAI[21].Add(0.675483676240548); MaxAI[21].Add(0.426781637945857);
            MaxAI[22].Add(0.0345155980033622); MaxAI[22].Add(0.0369503717072201); MaxAI[22].Add(0.0598500499687857); MaxAI[22].Add(0.228470264851486); MaxAI[22].Add(0.194791647193763); MaxAI[22].Add(0.675483676240548); MaxAI[22].Add(0.618143091158726);
            MaxAI[23].Add(0.0345155980033622); MaxAI[23].Add(0.0369503717072201); MaxAI[23].Add(0.0598500499687857); MaxAI[23].Add(0.228470264851486); MaxAI[23].Add(0.194791647193763); MaxAI[23].Add(0.675483676240548); MaxAI[23].Add(0.86466887761935); MaxAI[23].Add(0);
            MaxAI[24].Add(0.0345155980033622); MaxAI[24].Add(0.0369503717072201); MaxAI[24].Add(0.0598500499687857); MaxAI[24].Add(0.228470264851486); MaxAI[24].Add(0.194791647193763); MaxAI[24].Add(0.675483676240548); MaxAI[24].Add(1.02506569169063); MaxAI[24].Add(0.20632946414897);
            MaxAI[25].Add(0.0345155980033622); MaxAI[25].Add(0.0369503717072201); MaxAI[25].Add(0.0598500499687857); MaxAI[25].Add(0.228470264851486); MaxAI[25].Add(0.194791647193763); MaxAI[25].Add(0.675483676240548); MaxAI[25].Add(1.18140570356758); MaxAI[25].Add(0.407440384352653);
            MaxAI[26].Add(0.0345155980033622); MaxAI[26].Add(0.0369503717072201); MaxAI[26].Add(0.0598500499687857); MaxAI[26].Add(0.228470264851486); MaxAI[26].Add(0.194791647193763); MaxAI[26].Add(0.675483676240548); MaxAI[26].Add(1.32828216772821); MaxAI[26].Add(0.596377691629149);
            MaxAI[27].Add(0.0345155980033622); MaxAI[27].Add(0.0369503717072201); MaxAI[27].Add(0.0598500499687857); MaxAI[27].Add(0.228470264851486); MaxAI[27].Add(0.194791647193763); MaxAI[27].Add(0.675483676240548); MaxAI[27].Add(1.4835422259211); MaxAI[27].Add(0.796099393061705);
            MaxAI[28].Add(0.0345155980033622); MaxAI[28].Add(0.0369503717072201); MaxAI[28].Add(0.0598500499687857); MaxAI[28].Add(0.228470264851486); MaxAI[28].Add(0.194791647193763); MaxAI[28].Add(0.675483676240548); MaxAI[28].Add(1.4835422259211); MaxAI[28].Add(1.10128166280763); MaxAI[28].Add(0);
            MaxAI[29].Add(0.0345155980033622); MaxAI[29].Add(0.0369503717072201); MaxAI[29].Add(0.0598500499687857); MaxAI[29].Add(0.228470264851486); MaxAI[29].Add(0.194791647193763); MaxAI[29].Add(0.675483676240548); MaxAI[29].Add(1.4835422259211); MaxAI[29].Add(1.30423794973146); MaxAI[29].Add(0.172106931311405);
            MaxAI[30].Add(0.0345155980033622); MaxAI[30].Add(0.0369503717072201); MaxAI[30].Add(0.0598500499687857); MaxAI[30].Add(0.228470264851486); MaxAI[30].Add(0.194791647193763); MaxAI[30].Add(0.675483676240548); MaxAI[30].Add(1.4835422259211); MaxAI[30].Add(1.53797724579889); MaxAI[30].Add(0.370317854376584);
            MaxAI[31].Add(0.0345155980033622); MaxAI[31].Add(0.0369503717072201); MaxAI[31].Add(0.0598500499687857); MaxAI[31].Add(0.228470264851486); MaxAI[31].Add(0.194791647193763); MaxAI[31].Add(0.675483676240548); MaxAI[31].Add(1.4835422259211); MaxAI[31].Add(1.76625024971234); MaxAI[31].Add(0.563893361695193);
            MaxAI[32].Add(0.0345155980033622); MaxAI[32].Add(0.0369503717072201); MaxAI[32].Add(0.0598500499687857); MaxAI[32].Add(0.228470264851486); MaxAI[32].Add(0.194791647193763); MaxAI[32].Add(0.675483676240548); MaxAI[32].Add(1.4835422259211); MaxAI[32].Add(1.99051241251816); MaxAI[32].Add(0.754067675754529);
            MaxAI[33].Add(0.0345155980033622); MaxAI[33].Add(0.0369503717072201); MaxAI[33].Add(0.0598500499687857); MaxAI[33].Add(0.228470264851486); MaxAI[33].Add(0.194791647193763); MaxAI[33].Add(0.675483676240548); MaxAI[33].Add(1.4835422259211); MaxAI[33].Add(2.21478607330034); MaxAI[33].Add(0.944251740097817);
            MaxAI[34].Add(0.0345155980033622); MaxAI[34].Add(0.0369503717072201); MaxAI[34].Add(0.0598500499687857); MaxAI[34].Add(0.228470264851486); MaxAI[34].Add(0.194791647193763); MaxAI[34].Add(0.675483676240548); MaxAI[34].Add(1.4835422259211); MaxAI[34].Add(2.21478607330034); MaxAI[34].Add(1.16693961251959);
            MaxAI[35].Add(0.0345155980033622); MaxAI[35].Add(0.0369503717072201); MaxAI[35].Add(0.0598500499687857); MaxAI[35].Add(0.228470264851486); MaxAI[35].Add(0.194791647193763); MaxAI[35].Add(0.675483676240548); MaxAI[35].Add(1.4835422259211); MaxAI[35].Add(2.21478607330034); MaxAI[35].Add(1.42904767822622);
            MaxAI[36].Add(0.0345155980033622); MaxAI[36].Add(0.0369503717072201); MaxAI[36].Add(0.0598500499687857); MaxAI[36].Add(0.228470264851486); MaxAI[36].Add(0.194791647193763); MaxAI[36].Add(0.675483676240548); MaxAI[36].Add(1.4835422259211); MaxAI[36].Add(2.21478607330034); MaxAI[36].Add(1.64389352643251);
            MaxAI[37].Add(0.0345155980033622); MaxAI[37].Add(0.0369503717072201); MaxAI[37].Add(0.0598500499687857); MaxAI[37].Add(0.228470264851486); MaxAI[37].Add(0.194791647193763); MaxAI[37].Add(0.675483676240548); MaxAI[37].Add(1.4835422259211); MaxAI[37].Add(2.21478607330034); MaxAI[37].Add(1.89294841222001);
            MaxAI[38].Add(0.0345155980033622); MaxAI[38].Add(0.0369503717072201); MaxAI[38].Add(0.0598500499687857); MaxAI[38].Add(0.228470264851486); MaxAI[38].Add(0.194791647193763); MaxAI[38].Add(0.675483676240548); MaxAI[38].Add(1.4835422259211); MaxAI[38].Add(2.21478607330034); MaxAI[38].Add(2.14099565525922);
            MaxAI[39].Add(0.0345155980033622); MaxAI[39].Add(0.0369503717072201); MaxAI[39].Add(0.0598500499687857); MaxAI[39].Add(0.228470264851486); MaxAI[39].Add(0.194791647193763); MaxAI[39].Add(0.675483676240548); MaxAI[39].Add(1.4835422259211); MaxAI[39].Add(2.21478607330034); MaxAI[39].Add(2.34955241068224);
            MaxAI[40].Add(0.0345155980033622); MaxAI[40].Add(0.0369503717072201); MaxAI[40].Add(0.0598500499687857); MaxAI[40].Add(0.228470264851486); MaxAI[40].Add(0.194791647193763); MaxAI[40].Add(0.675483676240548); MaxAI[40].Add(1.4835422259211); MaxAI[40].Add(2.21478607330034); MaxAI[40].Add(2.53634413569602);
            MaxAI[41].Add(0.0345155980033622); MaxAI[41].Add(0.0369503717072201); MaxAI[41].Add(0.0598500499687857); MaxAI[41].Add(0.228470264851486); MaxAI[41].Add(0.194791647193763); MaxAI[41].Add(0.675483676240548); MaxAI[41].Add(1.4835422259211); MaxAI[41].Add(2.21478607330034); MaxAI[41].Add(2.71585180655173);
            MaxAI[42].Add(0.0345155980033622); MaxAI[42].Add(0.0369503717072201); MaxAI[42].Add(0.0598500499687857); MaxAI[42].Add(0.228470264851486); MaxAI[42].Add(0.194791647193763); MaxAI[42].Add(0.675483676240548); MaxAI[42].Add(1.4835422259211); MaxAI[42].Add(2.21478607330034); MaxAI[42].Add(2.92212358629684);
            MaxAI[43].Add(0.0345155980033622); MaxAI[43].Add(0.0369503717072201); MaxAI[43].Add(0.0598500499687857); MaxAI[43].Add(0.228470264851486); MaxAI[43].Add(0.194791647193763); MaxAI[43].Add(0.675483676240548); MaxAI[43].Add(1.4835422259211); MaxAI[43].Add(2.21478607330034); MaxAI[43].Add(2.92212358629684);
            MaxAI[44].Add(0.0345155980033622); MaxAI[44].Add(0.0369503717072201); MaxAI[44].Add(0.0598500499687857); MaxAI[44].Add(0.228470264851486); MaxAI[44].Add(0.194791647193763); MaxAI[44].Add(0.675483676240548); MaxAI[44].Add(1.4835422259211); MaxAI[44].Add(2.21478607330034); MaxAI[44].Add(2.92212358629684);
            MaxAI[45].Add(0.0345155980033622); MaxAI[45].Add(0.0369503717072201); MaxAI[45].Add(0.0598500499687857); MaxAI[45].Add(0.228470264851486); MaxAI[45].Add(0.194791647193763); MaxAI[45].Add(0.675483676240548); MaxAI[45].Add(1.4835422259211); MaxAI[45].Add(2.21478607330034); MaxAI[45].Add(2.92212358629684);
            MaxAI[46].Add(0.0345155980033622); MaxAI[46].Add(0.0369503717072201); MaxAI[46].Add(0.0598500499687857); MaxAI[46].Add(0.228470264851486); MaxAI[46].Add(0.194791647193763); MaxAI[46].Add(0.675483676240548); MaxAI[46].Add(1.4835422259211); MaxAI[46].Add(2.21478607330034); MaxAI[46].Add(2.92212358629684);
            MaxAI[47].Add(0.0345155980033622); MaxAI[47].Add(0.0369503717072201); MaxAI[47].Add(0.0598500499687857); MaxAI[47].Add(0.228470264851486); MaxAI[47].Add(0.194791647193763); MaxAI[47].Add(0.675483676240548); MaxAI[47].Add(1.4835422259211); MaxAI[47].Add(2.21478607330034); MaxAI[47].Add(2.92212358629684);
            MaxAI[48].Add(0.0345155980033622); MaxAI[48].Add(0.0369503717072201); MaxAI[48].Add(0.0598500499687857); MaxAI[48].Add(0.228470264851486); MaxAI[48].Add(0.194791647193763); MaxAI[48].Add(0.675483676240548); MaxAI[48].Add(1.4835422259211); MaxAI[48].Add(2.21478607330034); MaxAI[48].Add(2.92212358629684);
            MaxAI[49].Add(0.0345155980033622); MaxAI[49].Add(0.0369503717072201); MaxAI[49].Add(0.0598500499687857); MaxAI[49].Add(0.228470264851486); MaxAI[49].Add(0.194791647193763); MaxAI[49].Add(0.675483676240548); MaxAI[49].Add(1.4835422259211); MaxAI[49].Add(2.21478607330034); MaxAI[49].Add(2.92212358629684);
            MaxAI[50].Add(0.0345155980033622); MaxAI[50].Add(0.0369503717072201); MaxAI[50].Add(0.0598500499687857); MaxAI[50].Add(0.228470264851486); MaxAI[50].Add(0.194791647193763); MaxAI[50].Add(0.675483676240548); MaxAI[50].Add(1.4835422259211); MaxAI[50].Add(2.21478607330034); MaxAI[50].Add(2.92212358629684);
            MaxAI[51].Add(0.0345155980033622); MaxAI[51].Add(0.0369503717072201); MaxAI[51].Add(0.0598500499687857); MaxAI[51].Add(0.228470264851486); MaxAI[51].Add(0.194791647193763); MaxAI[51].Add(0.675483676240548); MaxAI[51].Add(1.4835422259211); MaxAI[51].Add(2.21478607330034); MaxAI[51].Add(2.92212358629684);
            MaxAI[52].Add(0.0345155980033622); MaxAI[52].Add(0.0369503717072201); MaxAI[52].Add(0.0598500499687857); MaxAI[52].Add(0.228470264851486); MaxAI[52].Add(0.194791647193763); MaxAI[52].Add(0.675483676240548); MaxAI[52].Add(1.4835422259211); MaxAI[52].Add(2.21478607330034); MaxAI[52].Add(2.92212358629684);
            MaxAI[53].Add(0.0345155980033622); MaxAI[53].Add(0.0369503717072201); MaxAI[53].Add(0.0598500499687857); MaxAI[53].Add(0.228470264851486); MaxAI[53].Add(0.194791647193763); MaxAI[53].Add(0.675483676240548); MaxAI[53].Add(1.4835422259211); MaxAI[53].Add(2.21478607330034); MaxAI[53].Add(2.92212358629684);
            MaxAI[54].Add(0.0345155980033622); MaxAI[54].Add(0.0369503717072201); MaxAI[54].Add(0.0598500499687857); MaxAI[54].Add(0.228470264851486); MaxAI[54].Add(0.194791647193763); MaxAI[54].Add(0.675483676240548); MaxAI[54].Add(1.4835422259211); MaxAI[54].Add(2.21478607330034); MaxAI[54].Add(2.92212358629684);
            MaxAI[55].Add(0.0345155980033622); MaxAI[55].Add(0.0369503717072201); MaxAI[55].Add(0.0598500499687857); MaxAI[55].Add(0.228470264851486); MaxAI[55].Add(0.194791647193763); MaxAI[55].Add(0.675483676240548); MaxAI[55].Add(1.4835422259211); MaxAI[55].Add(2.21478607330034); MaxAI[55].Add(2.92212358629684);
            MaxAI[56].Add(0.0345155980033622); MaxAI[56].Add(0.0369503717072201); MaxAI[56].Add(0.0598500499687857); MaxAI[56].Add(0.228470264851486); MaxAI[56].Add(0.194791647193763); MaxAI[56].Add(0.675483676240548); MaxAI[56].Add(1.4835422259211); MaxAI[56].Add(2.21478607330034); MaxAI[56].Add(2.92212358629684);
            MaxAI[57].Add(0.0345155980033622); MaxAI[57].Add(0.0369503717072201); MaxAI[57].Add(0.0598500499687857); MaxAI[57].Add(0.228470264851486); MaxAI[57].Add(0.194791647193763); MaxAI[57].Add(0.675483676240548); MaxAI[57].Add(1.4835422259211); MaxAI[57].Add(2.21478607330034); MaxAI[57].Add(2.92212358629684);
            MaxAI[58].Add(0.0345155980033622); MaxAI[58].Add(0.0369503717072201); MaxAI[58].Add(0.0598500499687857); MaxAI[58].Add(0.228470264851486); MaxAI[58].Add(0.194791647193763); MaxAI[58].Add(0.675483676240548); MaxAI[58].Add(1.4835422259211); MaxAI[58].Add(2.21478607330034); MaxAI[58].Add(2.92212358629684);
            MaxAI[59].Add(0.0345155980033622); MaxAI[59].Add(0.0369503717072201); MaxAI[59].Add(0.0598500499687857); MaxAI[59].Add(0.228470264851486); MaxAI[59].Add(0.194791647193763); MaxAI[59].Add(0.675483676240548); MaxAI[59].Add(1.4835422259211); MaxAI[59].Add(2.21478607330034); MaxAI[59].Add(2.92212358629684);
            MaxAI[60].Add(0.0345155980033622); MaxAI[60].Add(0.0369503717072201); MaxAI[60].Add(0.0598500499687857); MaxAI[60].Add(0.228470264851486); MaxAI[60].Add(0.194791647193763); MaxAI[60].Add(0.675483676240548); MaxAI[60].Add(1.4835422259211); MaxAI[60].Add(2.21478607330034); MaxAI[60].Add(2.92212358629684);
            MaxAI[61].Add(0.0345155980033622); MaxAI[61].Add(0.0369503717072201); MaxAI[61].Add(0.0598500499687857); MaxAI[61].Add(0.228470264851486); MaxAI[61].Add(0.194791647193763); MaxAI[61].Add(0.675483676240548); MaxAI[61].Add(1.4835422259211); MaxAI[61].Add(2.21478607330034); MaxAI[61].Add(2.92212358629684);
            MaxAI[62].Add(0.0345155980033622); MaxAI[62].Add(0.0369503717072201); MaxAI[62].Add(0.0598500499687857); MaxAI[62].Add(0.228470264851486); MaxAI[62].Add(0.194791647193763); MaxAI[62].Add(0.675483676240548); MaxAI[62].Add(1.4835422259211); MaxAI[62].Add(2.21478607330034); MaxAI[62].Add(2.92212358629684);
            MaxAI[63].Add(0.0345155980033622); MaxAI[63].Add(0.0369503717072201); MaxAI[63].Add(0.0598500499687857); MaxAI[63].Add(0.228470264851486); MaxAI[63].Add(0.194791647193763); MaxAI[63].Add(0.675483676240548); MaxAI[63].Add(1.4835422259211); MaxAI[63].Add(2.21478607330034); MaxAI[63].Add(2.92212358629684);
            MaxAI[64].Add(0.0345155980033622); MaxAI[64].Add(0.0369503717072201); MaxAI[64].Add(0.0598500499687857); MaxAI[64].Add(0.228470264851486); MaxAI[64].Add(0.194791647193763); MaxAI[64].Add(0.675483676240548); MaxAI[64].Add(1.4835422259211); MaxAI[64].Add(2.21478607330034); MaxAI[64].Add(2.92212358629684);
            MaxAI[65].Add(0.0345155980033622); MaxAI[65].Add(0.0369503717072201); MaxAI[65].Add(0.0598500499687857); MaxAI[65].Add(0.228470264851486); MaxAI[65].Add(0.194791647193763); MaxAI[65].Add(0.675483676240548); MaxAI[65].Add(1.4835422259211); MaxAI[65].Add(2.21478607330034); MaxAI[65].Add(2.92212358629684);
            MaxAI[66].Add(0.0345155980033622); MaxAI[66].Add(0.0369503717072201); MaxAI[66].Add(0.0598500499687857); MaxAI[66].Add(0.228470264851486); MaxAI[66].Add(0.194791647193763); MaxAI[66].Add(0.675483676240548); MaxAI[66].Add(1.4835422259211); MaxAI[66].Add(2.21478607330034); MaxAI[66].Add(2.92212358629684);
            MaxAI[67].Add(0.0345155980033622); MaxAI[67].Add(0.0369503717072201); MaxAI[67].Add(0.0598500499687857); MaxAI[67].Add(0.228470264851486); MaxAI[67].Add(0.194791647193763); MaxAI[67].Add(0.675483676240548); MaxAI[67].Add(1.4835422259211); MaxAI[67].Add(2.21478607330034); MaxAI[67].Add(2.92212358629684);
            MaxAI[68].Add(0.0345155980033622); MaxAI[68].Add(0.0369503717072201); MaxAI[68].Add(0.0598500499687857); MaxAI[68].Add(0.228470264851486); MaxAI[68].Add(0.194791647193763); MaxAI[68].Add(0.675483676240548); MaxAI[68].Add(1.4835422259211); MaxAI[68].Add(2.21478607330034); MaxAI[68].Add(2.92212358629684);
            #endregion

            List<List<double>> LayerPhyllochron = new List<List<double>>();
            #region Valorization
            LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>()); LayerPhyllochron.Add(new List<double>());
            LayerPhyllochron[0].Add(36.48);
            LayerPhyllochron[1].Add(36.48); LayerPhyllochron[1].Add(36.48);
            LayerPhyllochron[2].Add(36.48); LayerPhyllochron[2].Add(36.48);
            LayerPhyllochron[3].Add(36.48); LayerPhyllochron[3].Add(36.48);
            LayerPhyllochron[4].Add(36.48); LayerPhyllochron[4].Add(36.48); LayerPhyllochron[4].Add(36.48);
            LayerPhyllochron[5].Add(36.48); LayerPhyllochron[5].Add(36.48); LayerPhyllochron[5].Add(36.48);
            LayerPhyllochron[6].Add(36.48); LayerPhyllochron[6].Add(36.48); LayerPhyllochron[6].Add(36.48); LayerPhyllochron[6].Add(91.2);
            LayerPhyllochron[7].Add(36.48); LayerPhyllochron[7].Add(36.48); LayerPhyllochron[7].Add(36.48); LayerPhyllochron[7].Add(91.2);
            LayerPhyllochron[8].Add(36.48); LayerPhyllochron[8].Add(36.48); LayerPhyllochron[8].Add(36.48); LayerPhyllochron[8].Add(91.2);
            LayerPhyllochron[9].Add(36.48); LayerPhyllochron[9].Add(36.48); LayerPhyllochron[9].Add(36.48); LayerPhyllochron[9].Add(91.2); LayerPhyllochron[9].Add(91.2);
            LayerPhyllochron[10].Add(36.48); LayerPhyllochron[10].Add(36.48); LayerPhyllochron[10].Add(36.48); LayerPhyllochron[10].Add(91.2); LayerPhyllochron[10].Add(91.2);
            LayerPhyllochron[11].Add(36.48); LayerPhyllochron[11].Add(36.48); LayerPhyllochron[11].Add(36.48); LayerPhyllochron[11].Add(91.2); LayerPhyllochron[11].Add(91.2);
            LayerPhyllochron[12].Add(36.48); LayerPhyllochron[12].Add(36.48); LayerPhyllochron[12].Add(36.48); LayerPhyllochron[12].Add(91.2); LayerPhyllochron[12].Add(91.2);
            LayerPhyllochron[13].Add(36.48); LayerPhyllochron[13].Add(36.48); LayerPhyllochron[13].Add(36.48); LayerPhyllochron[13].Add(91.2); LayerPhyllochron[13].Add(91.2);
            LayerPhyllochron[14].Add(36.48); LayerPhyllochron[14].Add(36.48); LayerPhyllochron[14].Add(36.48); LayerPhyllochron[14].Add(91.2); LayerPhyllochron[14].Add(91.2); LayerPhyllochron[14].Add(91.2);
            LayerPhyllochron[15].Add(36.48); LayerPhyllochron[15].Add(36.48); LayerPhyllochron[15].Add(36.48); LayerPhyllochron[15].Add(91.2); LayerPhyllochron[15].Add(91.2); LayerPhyllochron[15].Add(91.2);
            LayerPhyllochron[16].Add(36.48); LayerPhyllochron[16].Add(36.48); LayerPhyllochron[16].Add(36.48); LayerPhyllochron[16].Add(91.2); LayerPhyllochron[16].Add(91.2); LayerPhyllochron[16].Add(91.2);
            LayerPhyllochron[17].Add(36.48); LayerPhyllochron[17].Add(36.48); LayerPhyllochron[17].Add(36.48); LayerPhyllochron[17].Add(91.2); LayerPhyllochron[17].Add(91.2); LayerPhyllochron[17].Add(91.2);
            LayerPhyllochron[18].Add(36.48); LayerPhyllochron[18].Add(36.48); LayerPhyllochron[18].Add(36.48); LayerPhyllochron[18].Add(91.2); LayerPhyllochron[18].Add(91.2); LayerPhyllochron[18].Add(91.2); LayerPhyllochron[18].Add(91.2);
            LayerPhyllochron[19].Add(36.48); LayerPhyllochron[19].Add(36.48); LayerPhyllochron[19].Add(36.48); LayerPhyllochron[19].Add(91.2); LayerPhyllochron[19].Add(91.2); LayerPhyllochron[19].Add(91.2); LayerPhyllochron[19].Add(91.2);
            LayerPhyllochron[20].Add(36.48); LayerPhyllochron[20].Add(36.48); LayerPhyllochron[20].Add(36.48); LayerPhyllochron[20].Add(91.2); LayerPhyllochron[20].Add(91.2); LayerPhyllochron[20].Add(91.2); LayerPhyllochron[20].Add(91.2);
            LayerPhyllochron[21].Add(36.48); LayerPhyllochron[21].Add(36.48); LayerPhyllochron[21].Add(36.48); LayerPhyllochron[21].Add(91.2); LayerPhyllochron[21].Add(91.2); LayerPhyllochron[21].Add(91.2); LayerPhyllochron[21].Add(91.2);
            LayerPhyllochron[22].Add(36.48); LayerPhyllochron[22].Add(36.48); LayerPhyllochron[22].Add(36.48); LayerPhyllochron[22].Add(91.2); LayerPhyllochron[22].Add(91.2); LayerPhyllochron[22].Add(91.2); LayerPhyllochron[22].Add(91.2);
            LayerPhyllochron[23].Add(36.48); LayerPhyllochron[23].Add(36.48); LayerPhyllochron[23].Add(36.48); LayerPhyllochron[23].Add(91.2); LayerPhyllochron[23].Add(91.2); LayerPhyllochron[23].Add(91.2); LayerPhyllochron[23].Add(91.2); LayerPhyllochron[23].Add(91.2);
            LayerPhyllochron[24].Add(36.48); LayerPhyllochron[24].Add(36.48); LayerPhyllochron[24].Add(36.48); LayerPhyllochron[24].Add(91.2); LayerPhyllochron[24].Add(91.2); LayerPhyllochron[24].Add(91.2); LayerPhyllochron[24].Add(91.2); LayerPhyllochron[24].Add(91.2);
            LayerPhyllochron[25].Add(36.48); LayerPhyllochron[25].Add(36.48); LayerPhyllochron[25].Add(36.48); LayerPhyllochron[25].Add(91.2); LayerPhyllochron[25].Add(91.2); LayerPhyllochron[25].Add(91.2); LayerPhyllochron[25].Add(91.2); LayerPhyllochron[25].Add(91.2);
            LayerPhyllochron[26].Add(36.48); LayerPhyllochron[26].Add(36.48); LayerPhyllochron[26].Add(36.48); LayerPhyllochron[26].Add(91.2); LayerPhyllochron[26].Add(91.2); LayerPhyllochron[26].Add(91.2); LayerPhyllochron[26].Add(91.2); LayerPhyllochron[26].Add(91.2);
            LayerPhyllochron[27].Add(36.48); LayerPhyllochron[27].Add(36.48); LayerPhyllochron[27].Add(36.48); LayerPhyllochron[27].Add(91.2); LayerPhyllochron[27].Add(91.2); LayerPhyllochron[27].Add(91.2); LayerPhyllochron[27].Add(91.2); LayerPhyllochron[27].Add(91.2);
            LayerPhyllochron[28].Add(36.48); LayerPhyllochron[28].Add(36.48); LayerPhyllochron[28].Add(36.48); LayerPhyllochron[28].Add(91.2); LayerPhyllochron[28].Add(91.2); LayerPhyllochron[28].Add(91.2); LayerPhyllochron[28].Add(91.2); LayerPhyllochron[28].Add(91.2); LayerPhyllochron[28].Add(114);
            LayerPhyllochron[29].Add(36.48); LayerPhyllochron[29].Add(36.48); LayerPhyllochron[29].Add(36.48); LayerPhyllochron[29].Add(91.2); LayerPhyllochron[29].Add(91.2); LayerPhyllochron[29].Add(91.2); LayerPhyllochron[29].Add(91.2); LayerPhyllochron[29].Add(91.2); LayerPhyllochron[29].Add(114);
            LayerPhyllochron[30].Add(36.48); LayerPhyllochron[30].Add(36.48); LayerPhyllochron[30].Add(36.48); LayerPhyllochron[30].Add(91.2); LayerPhyllochron[30].Add(91.2); LayerPhyllochron[30].Add(91.2); LayerPhyllochron[30].Add(91.2); LayerPhyllochron[30].Add(91.2); LayerPhyllochron[30].Add(114);
            LayerPhyllochron[31].Add(36.48); LayerPhyllochron[31].Add(36.48); LayerPhyllochron[31].Add(36.48); LayerPhyllochron[31].Add(91.2); LayerPhyllochron[31].Add(91.2); LayerPhyllochron[31].Add(91.2); LayerPhyllochron[31].Add(91.2); LayerPhyllochron[31].Add(91.2); LayerPhyllochron[31].Add(114);
            LayerPhyllochron[32].Add(36.48); LayerPhyllochron[32].Add(36.48); LayerPhyllochron[32].Add(36.48); LayerPhyllochron[32].Add(91.2); LayerPhyllochron[32].Add(91.2); LayerPhyllochron[32].Add(91.2); LayerPhyllochron[32].Add(91.2); LayerPhyllochron[32].Add(91.2); LayerPhyllochron[32].Add(114);
            LayerPhyllochron[33].Add(36.48); LayerPhyllochron[33].Add(36.48); LayerPhyllochron[33].Add(36.48); LayerPhyllochron[33].Add(91.2); LayerPhyllochron[33].Add(91.2); LayerPhyllochron[33].Add(91.2); LayerPhyllochron[33].Add(91.2); LayerPhyllochron[33].Add(91.2); LayerPhyllochron[33].Add(114);
            LayerPhyllochron[34].Add(36.48); LayerPhyllochron[34].Add(36.48); LayerPhyllochron[34].Add(36.48); LayerPhyllochron[34].Add(91.2); LayerPhyllochron[34].Add(91.2); LayerPhyllochron[34].Add(91.2); LayerPhyllochron[34].Add(91.2); LayerPhyllochron[34].Add(91.2); LayerPhyllochron[34].Add(114);
            LayerPhyllochron[35].Add(36.48); LayerPhyllochron[35].Add(36.48); LayerPhyllochron[35].Add(36.48); LayerPhyllochron[35].Add(91.2); LayerPhyllochron[35].Add(91.2); LayerPhyllochron[35].Add(91.2); LayerPhyllochron[35].Add(91.2); LayerPhyllochron[35].Add(91.2); LayerPhyllochron[35].Add(114);
            LayerPhyllochron[36].Add(36.48); LayerPhyllochron[36].Add(36.48); LayerPhyllochron[36].Add(36.48); LayerPhyllochron[36].Add(91.2); LayerPhyllochron[36].Add(91.2); LayerPhyllochron[36].Add(91.2); LayerPhyllochron[36].Add(91.2); LayerPhyllochron[36].Add(91.2); LayerPhyllochron[36].Add(114);
            LayerPhyllochron[37].Add(36.48); LayerPhyllochron[37].Add(36.48); LayerPhyllochron[37].Add(36.48); LayerPhyllochron[37].Add(91.2); LayerPhyllochron[37].Add(91.2); LayerPhyllochron[37].Add(91.2); LayerPhyllochron[37].Add(91.2); LayerPhyllochron[37].Add(91.2); LayerPhyllochron[37].Add(114);
            LayerPhyllochron[38].Add(36.48); LayerPhyllochron[38].Add(36.48); LayerPhyllochron[38].Add(36.48); LayerPhyllochron[38].Add(91.2); LayerPhyllochron[38].Add(91.2); LayerPhyllochron[38].Add(91.2); LayerPhyllochron[38].Add(91.2); LayerPhyllochron[38].Add(91.2); LayerPhyllochron[38].Add(114);
            LayerPhyllochron[39].Add(36.48); LayerPhyllochron[39].Add(36.48); LayerPhyllochron[39].Add(36.48); LayerPhyllochron[39].Add(91.2); LayerPhyllochron[39].Add(91.2); LayerPhyllochron[39].Add(91.2); LayerPhyllochron[39].Add(91.2); LayerPhyllochron[39].Add(91.2); LayerPhyllochron[39].Add(114);
            LayerPhyllochron[40].Add(36.48); LayerPhyllochron[40].Add(36.48); LayerPhyllochron[40].Add(36.48); LayerPhyllochron[40].Add(91.2); LayerPhyllochron[40].Add(91.2); LayerPhyllochron[40].Add(91.2); LayerPhyllochron[40].Add(91.2); LayerPhyllochron[40].Add(91.2); LayerPhyllochron[40].Add(114);
            LayerPhyllochron[41].Add(36.48); LayerPhyllochron[41].Add(36.48); LayerPhyllochron[41].Add(36.48); LayerPhyllochron[41].Add(91.2); LayerPhyllochron[41].Add(91.2); LayerPhyllochron[41].Add(91.2); LayerPhyllochron[41].Add(91.2); LayerPhyllochron[41].Add(91.2); LayerPhyllochron[41].Add(114);
            LayerPhyllochron[42].Add(36.48); LayerPhyllochron[42].Add(36.48); LayerPhyllochron[42].Add(36.48); LayerPhyllochron[42].Add(91.2); LayerPhyllochron[42].Add(91.2); LayerPhyllochron[42].Add(91.2); LayerPhyllochron[42].Add(91.2); LayerPhyllochron[42].Add(91.2); LayerPhyllochron[42].Add(114);
            LayerPhyllochron[43].Add(36.48); LayerPhyllochron[43].Add(36.48); LayerPhyllochron[43].Add(36.48); LayerPhyllochron[43].Add(91.2); LayerPhyllochron[43].Add(91.2); LayerPhyllochron[43].Add(91.2); LayerPhyllochron[43].Add(91.2); LayerPhyllochron[43].Add(91.2); LayerPhyllochron[43].Add(114);
            LayerPhyllochron[44].Add(36.48); LayerPhyllochron[44].Add(36.48); LayerPhyllochron[44].Add(36.48); LayerPhyllochron[44].Add(91.2); LayerPhyllochron[44].Add(91.2); LayerPhyllochron[44].Add(91.2); LayerPhyllochron[44].Add(91.2); LayerPhyllochron[44].Add(91.2); LayerPhyllochron[44].Add(114);
            LayerPhyllochron[45].Add(36.48); LayerPhyllochron[45].Add(36.48); LayerPhyllochron[45].Add(36.48); LayerPhyllochron[45].Add(91.2); LayerPhyllochron[45].Add(91.2); LayerPhyllochron[45].Add(91.2); LayerPhyllochron[45].Add(91.2); LayerPhyllochron[45].Add(91.2); LayerPhyllochron[45].Add(114);
            LayerPhyllochron[46].Add(36.48); LayerPhyllochron[46].Add(36.48); LayerPhyllochron[46].Add(36.48); LayerPhyllochron[46].Add(91.2); LayerPhyllochron[46].Add(91.2); LayerPhyllochron[46].Add(91.2); LayerPhyllochron[46].Add(91.2); LayerPhyllochron[46].Add(91.2); LayerPhyllochron[46].Add(114);
            LayerPhyllochron[47].Add(36.48); LayerPhyllochron[47].Add(36.48); LayerPhyllochron[47].Add(36.48); LayerPhyllochron[47].Add(91.2); LayerPhyllochron[47].Add(91.2); LayerPhyllochron[47].Add(91.2); LayerPhyllochron[47].Add(91.2); LayerPhyllochron[47].Add(91.2); LayerPhyllochron[47].Add(114);
            LayerPhyllochron[48].Add(36.48); LayerPhyllochron[48].Add(36.48); LayerPhyllochron[48].Add(36.48); LayerPhyllochron[48].Add(91.2); LayerPhyllochron[48].Add(91.2); LayerPhyllochron[48].Add(91.2); LayerPhyllochron[48].Add(91.2); LayerPhyllochron[48].Add(91.2); LayerPhyllochron[48].Add(114);
            LayerPhyllochron[49].Add(36.48); LayerPhyllochron[49].Add(36.48); LayerPhyllochron[49].Add(36.48); LayerPhyllochron[49].Add(91.2); LayerPhyllochron[49].Add(91.2); LayerPhyllochron[49].Add(91.2); LayerPhyllochron[49].Add(91.2); LayerPhyllochron[49].Add(91.2); LayerPhyllochron[49].Add(114);
            LayerPhyllochron[50].Add(36.48); LayerPhyllochron[50].Add(36.48); LayerPhyllochron[50].Add(36.48); LayerPhyllochron[50].Add(91.2); LayerPhyllochron[50].Add(91.2); LayerPhyllochron[50].Add(91.2); LayerPhyllochron[50].Add(91.2); LayerPhyllochron[50].Add(91.2); LayerPhyllochron[50].Add(114);
            LayerPhyllochron[51].Add(36.48); LayerPhyllochron[51].Add(36.48); LayerPhyllochron[51].Add(36.48); LayerPhyllochron[51].Add(91.2); LayerPhyllochron[51].Add(91.2); LayerPhyllochron[51].Add(91.2); LayerPhyllochron[51].Add(91.2); LayerPhyllochron[51].Add(91.2); LayerPhyllochron[51].Add(114);
            LayerPhyllochron[52].Add(36.48); LayerPhyllochron[52].Add(36.48); LayerPhyllochron[52].Add(36.48); LayerPhyllochron[52].Add(91.2); LayerPhyllochron[52].Add(91.2); LayerPhyllochron[52].Add(91.2); LayerPhyllochron[52].Add(91.2); LayerPhyllochron[52].Add(91.2); LayerPhyllochron[52].Add(114);
            LayerPhyllochron[53].Add(36.48); LayerPhyllochron[53].Add(36.48); LayerPhyllochron[53].Add(36.48); LayerPhyllochron[53].Add(91.2); LayerPhyllochron[53].Add(91.2); LayerPhyllochron[53].Add(91.2); LayerPhyllochron[53].Add(91.2); LayerPhyllochron[53].Add(91.2); LayerPhyllochron[53].Add(114);
            LayerPhyllochron[54].Add(36.48); LayerPhyllochron[54].Add(36.48); LayerPhyllochron[54].Add(36.48); LayerPhyllochron[54].Add(91.2); LayerPhyllochron[54].Add(91.2); LayerPhyllochron[54].Add(91.2); LayerPhyllochron[54].Add(91.2); LayerPhyllochron[54].Add(91.2); LayerPhyllochron[54].Add(114);
            LayerPhyllochron[55].Add(36.48); LayerPhyllochron[55].Add(36.48); LayerPhyllochron[55].Add(36.48); LayerPhyllochron[55].Add(91.2); LayerPhyllochron[55].Add(91.2); LayerPhyllochron[55].Add(91.2); LayerPhyllochron[55].Add(91.2); LayerPhyllochron[55].Add(91.2); LayerPhyllochron[55].Add(114);
            LayerPhyllochron[56].Add(36.48); LayerPhyllochron[56].Add(36.48); LayerPhyllochron[56].Add(36.48); LayerPhyllochron[56].Add(91.2); LayerPhyllochron[56].Add(91.2); LayerPhyllochron[56].Add(91.2); LayerPhyllochron[56].Add(91.2); LayerPhyllochron[56].Add(91.2); LayerPhyllochron[56].Add(114);
            LayerPhyllochron[57].Add(36.48); LayerPhyllochron[57].Add(36.48); LayerPhyllochron[57].Add(36.48); LayerPhyllochron[57].Add(91.2); LayerPhyllochron[57].Add(91.2); LayerPhyllochron[57].Add(91.2); LayerPhyllochron[57].Add(91.2); LayerPhyllochron[57].Add(91.2); LayerPhyllochron[57].Add(114);
            LayerPhyllochron[58].Add(36.48); LayerPhyllochron[58].Add(36.48); LayerPhyllochron[58].Add(36.48); LayerPhyllochron[58].Add(91.2); LayerPhyllochron[58].Add(91.2); LayerPhyllochron[58].Add(91.2); LayerPhyllochron[58].Add(91.2); LayerPhyllochron[58].Add(91.2); LayerPhyllochron[58].Add(114);
            LayerPhyllochron[59].Add(36.48); LayerPhyllochron[59].Add(36.48); LayerPhyllochron[59].Add(36.48); LayerPhyllochron[59].Add(91.2); LayerPhyllochron[59].Add(91.2); LayerPhyllochron[59].Add(91.2); LayerPhyllochron[59].Add(91.2); LayerPhyllochron[59].Add(91.2); LayerPhyllochron[59].Add(114);
            LayerPhyllochron[60].Add(36.48); LayerPhyllochron[60].Add(36.48); LayerPhyllochron[60].Add(36.48); LayerPhyllochron[60].Add(91.2); LayerPhyllochron[60].Add(91.2); LayerPhyllochron[60].Add(91.2); LayerPhyllochron[60].Add(91.2); LayerPhyllochron[60].Add(91.2); LayerPhyllochron[60].Add(114);
            LayerPhyllochron[61].Add(36.48); LayerPhyllochron[61].Add(36.48); LayerPhyllochron[61].Add(36.48); LayerPhyllochron[61].Add(91.2); LayerPhyllochron[61].Add(91.2); LayerPhyllochron[61].Add(91.2); LayerPhyllochron[61].Add(91.2); LayerPhyllochron[61].Add(91.2); LayerPhyllochron[61].Add(114);
            LayerPhyllochron[62].Add(36.48); LayerPhyllochron[62].Add(36.48); LayerPhyllochron[62].Add(36.48); LayerPhyllochron[62].Add(91.2); LayerPhyllochron[62].Add(91.2); LayerPhyllochron[62].Add(91.2); LayerPhyllochron[62].Add(91.2); LayerPhyllochron[62].Add(91.2); LayerPhyllochron[62].Add(114);
            LayerPhyllochron[63].Add(36.48); LayerPhyllochron[63].Add(36.48); LayerPhyllochron[63].Add(36.48); LayerPhyllochron[63].Add(91.2); LayerPhyllochron[63].Add(91.2); LayerPhyllochron[63].Add(91.2); LayerPhyllochron[63].Add(91.2); LayerPhyllochron[63].Add(91.2); LayerPhyllochron[63].Add(114);
            LayerPhyllochron[64].Add(36.48); LayerPhyllochron[64].Add(36.48); LayerPhyllochron[64].Add(36.48); LayerPhyllochron[64].Add(91.2); LayerPhyllochron[64].Add(91.2); LayerPhyllochron[64].Add(91.2); LayerPhyllochron[64].Add(91.2); LayerPhyllochron[64].Add(91.2); LayerPhyllochron[64].Add(114);
            LayerPhyllochron[65].Add(36.48); LayerPhyllochron[65].Add(36.48); LayerPhyllochron[65].Add(36.48); LayerPhyllochron[65].Add(91.2); LayerPhyllochron[65].Add(91.2); LayerPhyllochron[65].Add(91.2); LayerPhyllochron[65].Add(91.2); LayerPhyllochron[65].Add(91.2); LayerPhyllochron[65].Add(114);
            LayerPhyllochron[66].Add(36.48); LayerPhyllochron[66].Add(36.48); LayerPhyllochron[66].Add(36.48); LayerPhyllochron[66].Add(91.2); LayerPhyllochron[66].Add(91.2); LayerPhyllochron[66].Add(91.2); LayerPhyllochron[66].Add(91.2); LayerPhyllochron[66].Add(91.2); LayerPhyllochron[66].Add(114);
            LayerPhyllochron[67].Add(36.48); LayerPhyllochron[67].Add(36.48); LayerPhyllochron[67].Add(36.48); LayerPhyllochron[67].Add(91.2); LayerPhyllochron[67].Add(91.2); LayerPhyllochron[67].Add(91.2); LayerPhyllochron[67].Add(91.2); LayerPhyllochron[67].Add(91.2); LayerPhyllochron[67].Add(114);
            LayerPhyllochron[68].Add(36.48); LayerPhyllochron[68].Add(36.48); LayerPhyllochron[68].Add(36.48); LayerPhyllochron[68].Add(91.2); LayerPhyllochron[68].Add(91.2); LayerPhyllochron[68].Add(91.2); LayerPhyllochron[68].Add(91.2); LayerPhyllochron[68].Add(91.2); LayerPhyllochron[68].Add(114);
            #endregion

            List<List<double>> TTgroLamina = new List<List<double>>();
            #region Valorization
            TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>()); TTgroLamina.Add(new List<double>());
            TTgroLamina[0].Add(0);
            TTgroLamina[1].Add(40.128); TTgroLamina[1].Add(0);
            TTgroLamina[2].Add(40.128); TTgroLamina[2].Add(40.128);
            TTgroLamina[3].Add(40.128); TTgroLamina[3].Add(40.128);
            TTgroLamina[4].Add(40.128); TTgroLamina[4].Add(40.128); TTgroLamina[4].Add(0);
            TTgroLamina[5].Add(40.128); TTgroLamina[5].Add(40.128); TTgroLamina[5].Add(40.128);
            TTgroLamina[6].Add(40.128); TTgroLamina[6].Add(40.128); TTgroLamina[6].Add(40.128); TTgroLamina[6].Add(0);
            TTgroLamina[7].Add(40.128); TTgroLamina[7].Add(40.128); TTgroLamina[7].Add(40.128); TTgroLamina[7].Add(100.32);
            TTgroLamina[8].Add(40.128); TTgroLamina[8].Add(40.128); TTgroLamina[8].Add(40.128); TTgroLamina[8].Add(100.32);
            TTgroLamina[9].Add(40.128); TTgroLamina[9].Add(40.128); TTgroLamina[9].Add(40.128); TTgroLamina[9].Add(100.32); TTgroLamina[9].Add(0);
            TTgroLamina[10].Add(40.128); TTgroLamina[10].Add(40.128); TTgroLamina[10].Add(40.128); TTgroLamina[10].Add(100.32); TTgroLamina[10].Add(100.32);
            TTgroLamina[11].Add(40.128); TTgroLamina[11].Add(40.128); TTgroLamina[11].Add(40.128); TTgroLamina[11].Add(100.32); TTgroLamina[11].Add(100.32);
            TTgroLamina[12].Add(40.128); TTgroLamina[12].Add(40.128); TTgroLamina[12].Add(40.128); TTgroLamina[12].Add(100.32); TTgroLamina[12].Add(100.32);
            TTgroLamina[13].Add(40.128); TTgroLamina[13].Add(40.128); TTgroLamina[13].Add(40.128); TTgroLamina[13].Add(100.32); TTgroLamina[13].Add(100.32);
            TTgroLamina[14].Add(40.128); TTgroLamina[14].Add(40.128); TTgroLamina[14].Add(40.128); TTgroLamina[14].Add(100.32); TTgroLamina[14].Add(100.32); TTgroLamina[14].Add(0);
            TTgroLamina[15].Add(40.128); TTgroLamina[15].Add(40.128); TTgroLamina[15].Add(40.128); TTgroLamina[15].Add(100.32); TTgroLamina[15].Add(100.32); TTgroLamina[15].Add(100.32);
            TTgroLamina[16].Add(40.128); TTgroLamina[16].Add(40.128); TTgroLamina[16].Add(40.128); TTgroLamina[16].Add(100.32); TTgroLamina[16].Add(100.32); TTgroLamina[16].Add(100.32);
            TTgroLamina[17].Add(40.128); TTgroLamina[17].Add(40.128); TTgroLamina[17].Add(40.128); TTgroLamina[17].Add(100.32); TTgroLamina[17].Add(100.32); TTgroLamina[17].Add(100.32);
            TTgroLamina[18].Add(40.128); TTgroLamina[18].Add(40.128); TTgroLamina[18].Add(40.128); TTgroLamina[18].Add(100.32); TTgroLamina[18].Add(100.32); TTgroLamina[18].Add(100.32); TTgroLamina[18].Add(0);
            TTgroLamina[19].Add(40.128); TTgroLamina[19].Add(40.128); TTgroLamina[19].Add(40.128); TTgroLamina[19].Add(100.32); TTgroLamina[19].Add(100.32); TTgroLamina[19].Add(100.32); TTgroLamina[19].Add(100.32);
            TTgroLamina[20].Add(40.128); TTgroLamina[20].Add(40.128); TTgroLamina[20].Add(40.128); TTgroLamina[20].Add(100.32); TTgroLamina[20].Add(100.32); TTgroLamina[20].Add(100.32); TTgroLamina[20].Add(100.32);
            TTgroLamina[21].Add(40.128); TTgroLamina[21].Add(40.128); TTgroLamina[21].Add(40.128); TTgroLamina[21].Add(100.32); TTgroLamina[21].Add(100.32); TTgroLamina[21].Add(100.32); TTgroLamina[21].Add(100.32);
            TTgroLamina[22].Add(40.128); TTgroLamina[22].Add(40.128); TTgroLamina[22].Add(40.128); TTgroLamina[22].Add(100.32); TTgroLamina[22].Add(100.32); TTgroLamina[22].Add(100.32); TTgroLamina[22].Add(100.32);
            TTgroLamina[23].Add(40.128); TTgroLamina[23].Add(40.128); TTgroLamina[23].Add(40.128); TTgroLamina[23].Add(100.32); TTgroLamina[23].Add(100.32); TTgroLamina[23].Add(100.32); TTgroLamina[23].Add(100.32); TTgroLamina[23].Add(0);
            TTgroLamina[24].Add(40.128); TTgroLamina[24].Add(40.128); TTgroLamina[24].Add(40.128); TTgroLamina[24].Add(100.32); TTgroLamina[24].Add(100.32); TTgroLamina[24].Add(100.32); TTgroLamina[24].Add(100.32); TTgroLamina[24].Add(100.32);
            TTgroLamina[25].Add(40.128); TTgroLamina[25].Add(40.128); TTgroLamina[25].Add(40.128); TTgroLamina[25].Add(100.32); TTgroLamina[25].Add(100.32); TTgroLamina[25].Add(100.32); TTgroLamina[25].Add(100.32); TTgroLamina[25].Add(100.32);
            TTgroLamina[26].Add(40.128); TTgroLamina[26].Add(40.128); TTgroLamina[26].Add(40.128); TTgroLamina[26].Add(100.32); TTgroLamina[26].Add(100.32); TTgroLamina[26].Add(100.32); TTgroLamina[26].Add(100.32); TTgroLamina[26].Add(100.32);
            TTgroLamina[27].Add(40.128); TTgroLamina[27].Add(40.128); TTgroLamina[27].Add(40.128); TTgroLamina[27].Add(100.32); TTgroLamina[27].Add(100.32); TTgroLamina[27].Add(100.32); TTgroLamina[27].Add(100.32); TTgroLamina[27].Add(100.32);
            TTgroLamina[28].Add(40.128); TTgroLamina[28].Add(40.128); TTgroLamina[28].Add(40.128); TTgroLamina[28].Add(100.32); TTgroLamina[28].Add(100.32); TTgroLamina[28].Add(100.32); TTgroLamina[28].Add(100.32); TTgroLamina[28].Add(100.32); TTgroLamina[28].Add(0);
            TTgroLamina[29].Add(40.128); TTgroLamina[29].Add(40.128); TTgroLamina[29].Add(40.128); TTgroLamina[29].Add(100.32); TTgroLamina[29].Add(100.32); TTgroLamina[29].Add(100.32); TTgroLamina[29].Add(100.32); TTgroLamina[29].Add(100.32); TTgroLamina[29].Add(125.4);
            TTgroLamina[30].Add(40.128); TTgroLamina[30].Add(40.128); TTgroLamina[30].Add(40.128); TTgroLamina[30].Add(100.32); TTgroLamina[30].Add(100.32); TTgroLamina[30].Add(100.32); TTgroLamina[30].Add(100.32); TTgroLamina[30].Add(100.32); TTgroLamina[30].Add(125.4);
            TTgroLamina[31].Add(40.128); TTgroLamina[31].Add(40.128); TTgroLamina[31].Add(40.128); TTgroLamina[31].Add(100.32); TTgroLamina[31].Add(100.32); TTgroLamina[31].Add(100.32); TTgroLamina[31].Add(100.32); TTgroLamina[31].Add(100.32); TTgroLamina[31].Add(125.4);
            TTgroLamina[32].Add(40.128); TTgroLamina[32].Add(40.128); TTgroLamina[32].Add(40.128); TTgroLamina[32].Add(100.32); TTgroLamina[32].Add(100.32); TTgroLamina[32].Add(100.32); TTgroLamina[32].Add(100.32); TTgroLamina[32].Add(100.32); TTgroLamina[32].Add(125.4);
            TTgroLamina[33].Add(40.128); TTgroLamina[33].Add(40.128); TTgroLamina[33].Add(40.128); TTgroLamina[33].Add(100.32); TTgroLamina[33].Add(100.32); TTgroLamina[33].Add(100.32); TTgroLamina[33].Add(100.32); TTgroLamina[33].Add(100.32); TTgroLamina[33].Add(125.4);
            TTgroLamina[34].Add(40.128); TTgroLamina[34].Add(40.128); TTgroLamina[34].Add(40.128); TTgroLamina[34].Add(100.32); TTgroLamina[34].Add(100.32); TTgroLamina[34].Add(100.32); TTgroLamina[34].Add(100.32); TTgroLamina[34].Add(100.32); TTgroLamina[34].Add(125.4);
            TTgroLamina[35].Add(40.128); TTgroLamina[35].Add(40.128); TTgroLamina[35].Add(40.128); TTgroLamina[35].Add(100.32); TTgroLamina[35].Add(100.32); TTgroLamina[35].Add(100.32); TTgroLamina[35].Add(100.32); TTgroLamina[35].Add(100.32); TTgroLamina[35].Add(125.4);
            TTgroLamina[36].Add(40.128); TTgroLamina[36].Add(40.128); TTgroLamina[36].Add(40.128); TTgroLamina[36].Add(100.32); TTgroLamina[36].Add(100.32); TTgroLamina[36].Add(100.32); TTgroLamina[36].Add(100.32); TTgroLamina[36].Add(100.32); TTgroLamina[36].Add(125.4);
            TTgroLamina[37].Add(40.128); TTgroLamina[37].Add(40.128); TTgroLamina[37].Add(40.128); TTgroLamina[37].Add(100.32); TTgroLamina[37].Add(100.32); TTgroLamina[37].Add(100.32); TTgroLamina[37].Add(100.32); TTgroLamina[37].Add(100.32); TTgroLamina[37].Add(125.4);
            TTgroLamina[38].Add(40.128); TTgroLamina[38].Add(40.128); TTgroLamina[38].Add(40.128); TTgroLamina[38].Add(100.32); TTgroLamina[38].Add(100.32); TTgroLamina[38].Add(100.32); TTgroLamina[38].Add(100.32); TTgroLamina[38].Add(100.32); TTgroLamina[38].Add(125.4);
            TTgroLamina[39].Add(40.128); TTgroLamina[39].Add(40.128); TTgroLamina[39].Add(40.128); TTgroLamina[39].Add(100.32); TTgroLamina[39].Add(100.32); TTgroLamina[39].Add(100.32); TTgroLamina[39].Add(100.32); TTgroLamina[39].Add(100.32); TTgroLamina[39].Add(125.4);
            TTgroLamina[40].Add(40.128); TTgroLamina[40].Add(40.128); TTgroLamina[40].Add(40.128); TTgroLamina[40].Add(100.32); TTgroLamina[40].Add(100.32); TTgroLamina[40].Add(100.32); TTgroLamina[40].Add(100.32); TTgroLamina[40].Add(100.32); TTgroLamina[40].Add(125.4);
            TTgroLamina[41].Add(40.128); TTgroLamina[41].Add(40.128); TTgroLamina[41].Add(40.128); TTgroLamina[41].Add(100.32); TTgroLamina[41].Add(100.32); TTgroLamina[41].Add(100.32); TTgroLamina[41].Add(100.32); TTgroLamina[41].Add(100.32); TTgroLamina[41].Add(125.4);
            TTgroLamina[42].Add(40.128); TTgroLamina[42].Add(40.128); TTgroLamina[42].Add(40.128); TTgroLamina[42].Add(100.32); TTgroLamina[42].Add(100.32); TTgroLamina[42].Add(100.32); TTgroLamina[42].Add(100.32); TTgroLamina[42].Add(100.32); TTgroLamina[42].Add(125.4);
            TTgroLamina[43].Add(40.128); TTgroLamina[43].Add(40.128); TTgroLamina[43].Add(40.128); TTgroLamina[43].Add(100.32); TTgroLamina[43].Add(100.32); TTgroLamina[43].Add(100.32); TTgroLamina[43].Add(100.32); TTgroLamina[43].Add(100.32); TTgroLamina[43].Add(125.4);
            TTgroLamina[44].Add(40.128); TTgroLamina[44].Add(40.128); TTgroLamina[44].Add(40.128); TTgroLamina[44].Add(100.32); TTgroLamina[44].Add(100.32); TTgroLamina[44].Add(100.32); TTgroLamina[44].Add(100.32); TTgroLamina[44].Add(100.32); TTgroLamina[44].Add(125.4);
            TTgroLamina[45].Add(40.128); TTgroLamina[45].Add(40.128); TTgroLamina[45].Add(40.128); TTgroLamina[45].Add(100.32); TTgroLamina[45].Add(100.32); TTgroLamina[45].Add(100.32); TTgroLamina[45].Add(100.32); TTgroLamina[45].Add(100.32); TTgroLamina[45].Add(125.4);
            TTgroLamina[46].Add(40.128); TTgroLamina[46].Add(40.128); TTgroLamina[46].Add(40.128); TTgroLamina[46].Add(100.32); TTgroLamina[46].Add(100.32); TTgroLamina[46].Add(100.32); TTgroLamina[46].Add(100.32); TTgroLamina[46].Add(100.32); TTgroLamina[46].Add(125.4);
            TTgroLamina[47].Add(40.128); TTgroLamina[47].Add(40.128); TTgroLamina[47].Add(40.128); TTgroLamina[47].Add(100.32); TTgroLamina[47].Add(100.32); TTgroLamina[47].Add(100.32); TTgroLamina[47].Add(100.32); TTgroLamina[47].Add(100.32); TTgroLamina[47].Add(125.4);
            TTgroLamina[48].Add(40.128); TTgroLamina[48].Add(40.128); TTgroLamina[48].Add(40.128); TTgroLamina[48].Add(100.32); TTgroLamina[48].Add(100.32); TTgroLamina[48].Add(100.32); TTgroLamina[48].Add(100.32); TTgroLamina[48].Add(100.32); TTgroLamina[48].Add(125.4);
            TTgroLamina[49].Add(40.128); TTgroLamina[49].Add(40.128); TTgroLamina[49].Add(40.128); TTgroLamina[49].Add(100.32); TTgroLamina[49].Add(100.32); TTgroLamina[49].Add(100.32); TTgroLamina[49].Add(100.32); TTgroLamina[49].Add(100.32); TTgroLamina[49].Add(125.4);
            TTgroLamina[50].Add(40.128); TTgroLamina[50].Add(40.128); TTgroLamina[50].Add(40.128); TTgroLamina[50].Add(100.32); TTgroLamina[50].Add(100.32); TTgroLamina[50].Add(100.32); TTgroLamina[50].Add(100.32); TTgroLamina[50].Add(100.32); TTgroLamina[50].Add(125.4);
            TTgroLamina[51].Add(40.128); TTgroLamina[51].Add(40.128); TTgroLamina[51].Add(40.128); TTgroLamina[51].Add(100.32); TTgroLamina[51].Add(100.32); TTgroLamina[51].Add(100.32); TTgroLamina[51].Add(100.32); TTgroLamina[51].Add(100.32); TTgroLamina[51].Add(125.4);
            TTgroLamina[52].Add(40.128); TTgroLamina[52].Add(40.128); TTgroLamina[52].Add(40.128); TTgroLamina[52].Add(100.32); TTgroLamina[52].Add(100.32); TTgroLamina[52].Add(100.32); TTgroLamina[52].Add(100.32); TTgroLamina[52].Add(100.32); TTgroLamina[52].Add(125.4);
            TTgroLamina[53].Add(40.128); TTgroLamina[53].Add(40.128); TTgroLamina[53].Add(40.128); TTgroLamina[53].Add(100.32); TTgroLamina[53].Add(100.32); TTgroLamina[53].Add(100.32); TTgroLamina[53].Add(100.32); TTgroLamina[53].Add(100.32); TTgroLamina[53].Add(125.4);
            TTgroLamina[54].Add(40.128); TTgroLamina[54].Add(40.128); TTgroLamina[54].Add(40.128); TTgroLamina[54].Add(100.32); TTgroLamina[54].Add(100.32); TTgroLamina[54].Add(100.32); TTgroLamina[54].Add(100.32); TTgroLamina[54].Add(100.32); TTgroLamina[54].Add(125.4);
            TTgroLamina[55].Add(40.128); TTgroLamina[55].Add(40.128); TTgroLamina[55].Add(40.128); TTgroLamina[55].Add(100.32); TTgroLamina[55].Add(100.32); TTgroLamina[55].Add(100.32); TTgroLamina[55].Add(100.32); TTgroLamina[55].Add(100.32); TTgroLamina[55].Add(125.4);
            TTgroLamina[56].Add(40.128); TTgroLamina[56].Add(40.128); TTgroLamina[56].Add(40.128); TTgroLamina[56].Add(100.32); TTgroLamina[56].Add(100.32); TTgroLamina[56].Add(100.32); TTgroLamina[56].Add(100.32); TTgroLamina[56].Add(100.32); TTgroLamina[56].Add(125.4);
            TTgroLamina[57].Add(40.128); TTgroLamina[57].Add(40.128); TTgroLamina[57].Add(40.128); TTgroLamina[57].Add(100.32); TTgroLamina[57].Add(100.32); TTgroLamina[57].Add(100.32); TTgroLamina[57].Add(100.32); TTgroLamina[57].Add(100.32); TTgroLamina[57].Add(125.4);
            TTgroLamina[58].Add(40.128); TTgroLamina[58].Add(40.128); TTgroLamina[58].Add(40.128); TTgroLamina[58].Add(100.32); TTgroLamina[58].Add(100.32); TTgroLamina[58].Add(100.32); TTgroLamina[58].Add(100.32); TTgroLamina[58].Add(100.32); TTgroLamina[58].Add(125.4);
            TTgroLamina[59].Add(40.128); TTgroLamina[59].Add(40.128); TTgroLamina[59].Add(40.128); TTgroLamina[59].Add(100.32); TTgroLamina[59].Add(100.32); TTgroLamina[59].Add(100.32); TTgroLamina[59].Add(100.32); TTgroLamina[59].Add(100.32); TTgroLamina[59].Add(125.4);
            TTgroLamina[60].Add(40.128); TTgroLamina[60].Add(40.128); TTgroLamina[60].Add(40.128); TTgroLamina[60].Add(100.32); TTgroLamina[60].Add(100.32); TTgroLamina[60].Add(100.32); TTgroLamina[60].Add(100.32); TTgroLamina[60].Add(100.32); TTgroLamina[60].Add(125.4);
            TTgroLamina[61].Add(40.128); TTgroLamina[61].Add(40.128); TTgroLamina[61].Add(40.128); TTgroLamina[61].Add(100.32); TTgroLamina[61].Add(100.32); TTgroLamina[61].Add(100.32); TTgroLamina[61].Add(100.32); TTgroLamina[61].Add(100.32); TTgroLamina[61].Add(125.4);
            TTgroLamina[62].Add(40.128); TTgroLamina[62].Add(40.128); TTgroLamina[62].Add(40.128); TTgroLamina[62].Add(100.32); TTgroLamina[62].Add(100.32); TTgroLamina[62].Add(100.32); TTgroLamina[62].Add(100.32); TTgroLamina[62].Add(100.32); TTgroLamina[62].Add(125.4);
            TTgroLamina[63].Add(40.128); TTgroLamina[63].Add(40.128); TTgroLamina[63].Add(40.128); TTgroLamina[63].Add(100.32); TTgroLamina[63].Add(100.32); TTgroLamina[63].Add(100.32); TTgroLamina[63].Add(100.32); TTgroLamina[63].Add(100.32); TTgroLamina[63].Add(125.4);
            TTgroLamina[64].Add(40.128); TTgroLamina[64].Add(40.128); TTgroLamina[64].Add(40.128); TTgroLamina[64].Add(100.32); TTgroLamina[64].Add(100.32); TTgroLamina[64].Add(100.32); TTgroLamina[64].Add(100.32); TTgroLamina[64].Add(100.32); TTgroLamina[64].Add(125.4);
            TTgroLamina[65].Add(40.128); TTgroLamina[65].Add(40.128); TTgroLamina[65].Add(40.128); TTgroLamina[65].Add(100.32); TTgroLamina[65].Add(100.32); TTgroLamina[65].Add(100.32); TTgroLamina[65].Add(100.32); TTgroLamina[65].Add(100.32); TTgroLamina[65].Add(125.4);
            TTgroLamina[66].Add(40.128); TTgroLamina[66].Add(40.128); TTgroLamina[66].Add(40.128); TTgroLamina[66].Add(100.32); TTgroLamina[66].Add(100.32); TTgroLamina[66].Add(100.32); TTgroLamina[66].Add(100.32); TTgroLamina[66].Add(100.32); TTgroLamina[66].Add(125.4);
            TTgroLamina[67].Add(40.128); TTgroLamina[67].Add(40.128); TTgroLamina[67].Add(40.128); TTgroLamina[67].Add(100.32); TTgroLamina[67].Add(100.32); TTgroLamina[67].Add(100.32); TTgroLamina[67].Add(100.32); TTgroLamina[67].Add(100.32); TTgroLamina[67].Add(125.4);
            TTgroLamina[68].Add(40.128); TTgroLamina[68].Add(40.128); TTgroLamina[68].Add(40.128); TTgroLamina[68].Add(100.32); TTgroLamina[68].Add(100.32); TTgroLamina[68].Add(100.32); TTgroLamina[68].Add(100.32); TTgroLamina[68].Add(100.32); TTgroLamina[68].Add(125.4);
            #endregion

            List<List<double>> LaminaSpecificN = new List<List<double>>();
            #region Valorization
            LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>()); LaminaSpecificN.Add(new List<double>());
            LaminaSpecificN[0].Add(0);
            LaminaSpecificN[1].Add(0); LaminaSpecificN[1].Add(0);
            LaminaSpecificN[2].Add(0.674443284993528); LaminaSpecificN[2].Add(1.92555671500647);
            LaminaSpecificN[3].Add(0.705385291560009); LaminaSpecificN[3].Add(1.89461470843999);
            LaminaSpecificN[4].Add(0.678801864541444); LaminaSpecificN[4].Add(1.8172827200438); LaminaSpecificN[4].Add(0);
            LaminaSpecificN[5].Add(0.658953398072925); LaminaSpecificN[5].Add(1.27477676467873); LaminaSpecificN[5].Add(2.1905220537795);
            LaminaSpecificN[6].Add(0.561451567474928); LaminaSpecificN[6].Add(0.797592088485299); LaminaSpecificN[6].Add(1.944425918355); LaminaSpecificN[6].Add(0);
            LaminaSpecificN[7].Add(0.564374603858226); LaminaSpecificN[7].Add(0.707170364374075); LaminaSpecificN[7].Add(1.23267721605879); LaminaSpecificN[7].Add(2.20431424281666);
            LaminaSpecificN[8].Add(0.538712775721524); LaminaSpecificN[8].Add(0.626450992789153); LaminaSpecificN[8].Add(0.893873973120859); LaminaSpecificN[8].Add(2.06344157510589);
            LaminaSpecificN[9].Add(0.517751802913188); LaminaSpecificN[9].Add(0.538372090530062); LaminaSpecificN[9].Add(0.737781074663238); LaminaSpecificN[9].Add(2.3336896819997); LaminaSpecificN[9].Add(0);
            LaminaSpecificN[10].Add(0); LaminaSpecificN[10].Add(0); LaminaSpecificN[10].Add(0.569201833386444); LaminaSpecificN[10].Add(1.59030780148469); LaminaSpecificN[10].Add(2.48492016886063);
            LaminaSpecificN[11].Add(0); LaminaSpecificN[11].Add(0); LaminaSpecificN[11].Add(0); LaminaSpecificN[11].Add(1.44520312463836); LaminaSpecificN[11].Add(2.63525056758391);
            LaminaSpecificN[12].Add(0); LaminaSpecificN[12].Add(0); LaminaSpecificN[12].Add(0); LaminaSpecificN[12].Add(1.44520312463836); LaminaSpecificN[12].Add(2.63525056758391);
            LaminaSpecificN[13].Add(0); LaminaSpecificN[13].Add(0); LaminaSpecificN[13].Add(0); LaminaSpecificN[13].Add(1.44520312463836); LaminaSpecificN[13].Add(2.63525056758391);
            LaminaSpecificN[14].Add(0); LaminaSpecificN[14].Add(0); LaminaSpecificN[14].Add(0); LaminaSpecificN[14].Add(1.30788502578328); LaminaSpecificN[14].Add(2.66804135155287); LaminaSpecificN[14].Add(0);
            LaminaSpecificN[15].Add(0); LaminaSpecificN[15].Add(0); LaminaSpecificN[15].Add(0); LaminaSpecificN[15].Add(0.87759343901552); LaminaSpecificN[15].Add(1.60146134706984); LaminaSpecificN[15].Add(2.34787540762354);
            LaminaSpecificN[16].Add(0); LaminaSpecificN[16].Add(0); LaminaSpecificN[16].Add(0); LaminaSpecificN[16].Add(0.838515493874296); LaminaSpecificN[16].Add(1.34297434854194); LaminaSpecificN[16].Add(2.47285908511776);
            LaminaSpecificN[17].Add(0); LaminaSpecificN[17].Add(0); LaminaSpecificN[17].Add(0); LaminaSpecificN[17].Add(0.780800006453657); LaminaSpecificN[17].Add(1.11428631816383); LaminaSpecificN[17].Add(2.44698941147099);
            LaminaSpecificN[18].Add(0); LaminaSpecificN[18].Add(0); LaminaSpecificN[18].Add(0); LaminaSpecificN[18].Add(0.718278413095162); LaminaSpecificN[18].Add(0.964145048405394); LaminaSpecificN[18].Add(2.37799270837458); LaminaSpecificN[18].Add(0);
            LaminaSpecificN[19].Add(0); LaminaSpecificN[19].Add(0); LaminaSpecificN[19].Add(0); LaminaSpecificN[19].Add(0.651092904312779); LaminaSpecificN[19].Add(0.782285939232026); LaminaSpecificN[19].Add(1.68589460124296); LaminaSpecificN[19].Add(2.23649035664815);
            LaminaSpecificN[20].Add(0); LaminaSpecificN[20].Add(0); LaminaSpecificN[20].Add(0); LaminaSpecificN[20].Add(0.678949459705473); LaminaSpecificN[20].Add(0.797811997805638); LaminaSpecificN[20].Add(1.52225178446741); LaminaSpecificN[20].Add(2.30358864513836);
            LaminaSpecificN[21].Add(0); LaminaSpecificN[21].Add(0); LaminaSpecificN[21].Add(0); LaminaSpecificN[21].Add(0.675606435726277); LaminaSpecificN[21].Add(0.784355993141597); LaminaSpecificN[21].Add(1.41727304364163); LaminaSpecificN[21].Add(2.41319474517266);
            LaminaSpecificN[22].Add(0); LaminaSpecificN[22].Add(0); LaminaSpecificN[22].Add(0); LaminaSpecificN[22].Add(0.666339211438661); LaminaSpecificN[22].Add(0.756836514164315); LaminaSpecificN[22].Add(1.24184933619963); LaminaSpecificN[22].Add(2.40250154617687);
            LaminaSpecificN[23].Add(0); LaminaSpecificN[23].Add(0); LaminaSpecificN[23].Add(0); LaminaSpecificN[23].Add(0.641781095648312); LaminaSpecificN[23].Add(0.712101178609885); LaminaSpecificN[23].Add(1.06017555863965); LaminaSpecificN[23].Add(2.28163012446011); LaminaSpecificN[23].Add(0);
            LaminaSpecificN[24].Add(0); LaminaSpecificN[24].Add(0); LaminaSpecificN[24].Add(0); LaminaSpecificN[24].Add(0.603213090382466); LaminaSpecificN[24].Add(0.651447679238377); LaminaSpecificN[24].Add(0.869335361532532); LaminaSpecificN[24].Add(1.7564844198021); LaminaSpecificN[24].Add(2.06881035615615);
            LaminaSpecificN[25].Add(0); LaminaSpecificN[25].Add(0); LaminaSpecificN[25].Add(0); LaminaSpecificN[25].Add(0); LaminaSpecificN[25].Add(0.682410291985016); LaminaSpecificN[25].Add(0.871716087040332); LaminaSpecificN[25].Add(1.58109081098727); LaminaSpecificN[25].Add(2.08177651439289);
            LaminaSpecificN[26].Add(0); LaminaSpecificN[26].Add(0); LaminaSpecificN[26].Add(0); LaminaSpecificN[26].Add(0); LaminaSpecificN[26].Add(0.70135726587392); LaminaSpecificN[26].Add(0.867055809643769); LaminaSpecificN[26].Add(1.4474765178657); LaminaSpecificN[26].Add(2.05043231790406);
            LaminaSpecificN[27].Add(0); LaminaSpecificN[27].Add(0); LaminaSpecificN[27].Add(0); LaminaSpecificN[27].Add(0); LaminaSpecificN[27].Add(0.713474775140488); LaminaSpecificN[27].Add(0.854861322376011); LaminaSpecificN[27].Add(1.33295862726264); LaminaSpecificN[27].Add(1.99916486539061);
            LaminaSpecificN[28].Add(0); LaminaSpecificN[28].Add(0); LaminaSpecificN[28].Add(0); LaminaSpecificN[28].Add(0); LaminaSpecificN[28].Add(0.693305590315531); LaminaSpecificN[28].Add(0.811626182997567); LaminaSpecificN[28].Add(1.19245199977776); LaminaSpecificN[28].Add(1.95777318985375); LaminaSpecificN[28].Add(0);
            LaminaSpecificN[29].Add(0); LaminaSpecificN[29].Add(0); LaminaSpecificN[29].Add(0); LaminaSpecificN[29].Add(0); LaminaSpecificN[29].Add(0.674562057573617); LaminaSpecificN[29].Add(0.771575056342682); LaminaSpecificN[29].Add(1.0671221567648); LaminaSpecificN[29].Add(1.78885762005798); LaminaSpecificN[29].Add(1.92734142942627);
            LaminaSpecificN[30].Add(0); LaminaSpecificN[30].Add(0); LaminaSpecificN[30].Add(0); LaminaSpecificN[30].Add(0); LaminaSpecificN[30].Add(0.701891614732952); LaminaSpecificN[30].Add(0.791680556842472); LaminaSpecificN[30].Add(1.05081611205029); LaminaSpecificN[30].Add(1.66797423933242); LaminaSpecificN[30].Add(1.92685188060939);
            LaminaSpecificN[31].Add(0); LaminaSpecificN[31].Add(0); LaminaSpecificN[31].Add(0); LaminaSpecificN[31].Add(0); LaminaSpecificN[31].Add(0.721690292397936); LaminaSpecificN[31].Add(0.803875310317186); LaminaSpecificN[31].Add(1.03103513687588); LaminaSpecificN[31].Add(1.5646721069027); LaminaSpecificN[31].Add(1.90993054950757);
            LaminaSpecificN[32].Add(0); LaminaSpecificN[32].Add(0); LaminaSpecificN[32].Add(0); LaminaSpecificN[32].Add(0); LaminaSpecificN[32].Add(0.736086309273469); LaminaSpecificN[32].Add(0.810949877673326); LaminaSpecificN[32].Add(1.01070487964962); LaminaSpecificN[32].Add(1.47719287253827); LaminaSpecificN[32].Add(1.88506818787906);
            LaminaSpecificN[33].Add(0); LaminaSpecificN[33].Add(0); LaminaSpecificN[33].Add(0); LaminaSpecificN[33].Add(0); LaminaSpecificN[33].Add(0.747080126187544); LaminaSpecificN[33].Add(0.814889013092093); LaminaSpecificN[33].Add(0.990383432827305); LaminaSpecificN[33].Add(1.40135564041022); LaminaSpecificN[33].Add(1.85532765902158);
            LaminaSpecificN[34].Add(0); LaminaSpecificN[34].Add(0); LaminaSpecificN[34].Add(0); LaminaSpecificN[34].Add(0); LaminaSpecificN[34].Add(0.742491548540344); LaminaSpecificN[34].Add(0.806328368101478); LaminaSpecificN[34].Add(0.969762705736354); LaminaSpecificN[34].Add(1.34546506899653); LaminaSpecificN[34].Add(1.87111410333327);
            LaminaSpecificN[35].Add(0); LaminaSpecificN[35].Add(0); LaminaSpecificN[35].Add(0); LaminaSpecificN[35].Add(0); LaminaSpecificN[35].Add(0); LaminaSpecificN[35].Add(0.791726327907521); LaminaSpecificN[35].Add(0.940186596255528); LaminaSpecificN[35].Add(1.27423165484984); LaminaSpecificN[35].Add(1.86082098866874);
            LaminaSpecificN[36].Add(0); LaminaSpecificN[36].Add(0); LaminaSpecificN[36].Add(0); LaminaSpecificN[36].Add(0); LaminaSpecificN[36].Add(0); LaminaSpecificN[36].Add(0.813440423934207); LaminaSpecificN[36].Add(0.961603463969802); LaminaSpecificN[36].Add(1.28964588836554); LaminaSpecificN[36].Add(1.85419855169542);
            LaminaSpecificN[37].Add(0); LaminaSpecificN[37].Add(0); LaminaSpecificN[37].Add(0); LaminaSpecificN[37].Add(0); LaminaSpecificN[37].Add(0); LaminaSpecificN[37].Add(0.835294947873533); LaminaSpecificN[37].Add(0.982105001231324); LaminaSpecificN[37].Add(1.30163747602903); LaminaSpecificN[37].Add(1.83990043670751);
            LaminaSpecificN[38].Add(0); LaminaSpecificN[38].Add(0); LaminaSpecificN[38].Add(0); LaminaSpecificN[38].Add(0); LaminaSpecificN[38].Add(0); LaminaSpecificN[38].Add(0.85569184933452); LaminaSpecificN[38].Add(1.00086116119838); LaminaSpecificN[38].Add(1.3119455897917); LaminaSpecificN[38].Add(1.82587156961828);
            LaminaSpecificN[39].Add(0); LaminaSpecificN[39].Add(0); LaminaSpecificN[39].Add(0); LaminaSpecificN[39].Add(0); LaminaSpecificN[39].Add(0); LaminaSpecificN[39].Add(0.873828541654094); LaminaSpecificN[39].Add(1.01798812059612); LaminaSpecificN[39].Add(1.32320347091315); LaminaSpecificN[39].Add(1.81986872007144);
            LaminaSpecificN[40].Add(0); LaminaSpecificN[40].Add(0); LaminaSpecificN[40].Add(0); LaminaSpecificN[40].Add(0); LaminaSpecificN[40].Add(0); LaminaSpecificN[40].Add(0.891667411359009); LaminaSpecificN[40].Add(1.03539541232609); LaminaSpecificN[40].Add(1.33663773164238); LaminaSpecificN[40].Add(1.82066873432784);
            LaminaSpecificN[41].Add(0); LaminaSpecificN[41].Add(0); LaminaSpecificN[41].Add(0); LaminaSpecificN[41].Add(0); LaminaSpecificN[41].Add(0); LaminaSpecificN[41].Add(0.908351443724354); LaminaSpecificN[41].Add(1.05155946050715); LaminaSpecificN[41].Add(1.34898078345251); LaminaSpecificN[41].Add(1.82142571512782);
            LaminaSpecificN[42].Add(0); LaminaSpecificN[42].Add(0); LaminaSpecificN[42].Add(0); LaminaSpecificN[42].Add(0); LaminaSpecificN[42].Add(0); LaminaSpecificN[42].Add(0.925090841724881); LaminaSpecificN[42].Add(1.06712438359563); LaminaSpecificN[42].Add(1.35920794539928); LaminaSpecificN[42].Add(1.81746152781223);
            LaminaSpecificN[43].Add(0); LaminaSpecificN[43].Add(0); LaminaSpecificN[43].Add(0); LaminaSpecificN[43].Add(0); LaminaSpecificN[43].Add(0); LaminaSpecificN[43].Add(0.936602638483413); LaminaSpecificN[43].Add(1.08147931599167); LaminaSpecificN[43].Add(1.37940961774671); LaminaSpecificN[43].Add(1.84683622417927);
            LaminaSpecificN[44].Add(0); LaminaSpecificN[44].Add(0); LaminaSpecificN[44].Add(0); LaminaSpecificN[44].Add(0); LaminaSpecificN[44].Add(0); LaminaSpecificN[44].Add(0.94752835668166); LaminaSpecificN[44].Add(1.09510342258456); LaminaSpecificN[44].Add(1.39858280016393); LaminaSpecificN[44].Add(1.87471542161451);
            LaminaSpecificN[45].Add(0); LaminaSpecificN[45].Add(0); LaminaSpecificN[45].Add(0); LaminaSpecificN[45].Add(0); LaminaSpecificN[45].Add(0); LaminaSpecificN[45].Add(0.957895922895315); LaminaSpecificN[45].Add(1.10803152713941); LaminaSpecificN[45].Add(1.4167765000773); LaminaSpecificN[45].Add(1.90117038046928);
            LaminaSpecificN[46].Add(0); LaminaSpecificN[46].Add(0); LaminaSpecificN[46].Add(0); LaminaSpecificN[46].Add(0); LaminaSpecificN[46].Add(0); LaminaSpecificN[46].Add(0.967718030411401); LaminaSpecificN[46].Add(1.12027945787842); LaminaSpecificN[46].Add(1.43401299251747); LaminaSpecificN[46].Add(1.92623349025322);
            LaminaSpecificN[47].Add(0); LaminaSpecificN[47].Add(0); LaminaSpecificN[47].Add(0); LaminaSpecificN[47].Add(0); LaminaSpecificN[47].Add(0); LaminaSpecificN[47].Add(0.976359370301437); LaminaSpecificN[47].Add(1.13105499991886); LaminaSpecificN[47].Add(1.44917739480523); LaminaSpecificN[47].Add(1.94828363071337);
            LaminaSpecificN[48].Add(0); LaminaSpecificN[48].Add(0); LaminaSpecificN[48].Add(0); LaminaSpecificN[48].Add(0); LaminaSpecificN[48].Add(0); LaminaSpecificN[48].Add(0.984148215558254); LaminaSpecificN[48].Add(1.14076750175069); LaminaSpecificN[48].Add(1.46284578238568); LaminaSpecificN[48].Add(1.96815845731673);
            LaminaSpecificN[49].Add(0); LaminaSpecificN[49].Add(0); LaminaSpecificN[49].Add(0); LaminaSpecificN[49].Add(0); LaminaSpecificN[49].Add(0); LaminaSpecificN[49].Add(0.991093532942063); LaminaSpecificN[49].Add(1.1494281447072); LaminaSpecificN[49].Add(1.47503389073051); LaminaSpecificN[49].Add(1.98588085058005);
            LaminaSpecificN[50].Add(0); LaminaSpecificN[50].Add(0); LaminaSpecificN[50].Add(0); LaminaSpecificN[50].Add(0); LaminaSpecificN[50].Add(0); LaminaSpecificN[50].Add(0.994018582577329); LaminaSpecificN[50].Add(1.15470291613581); LaminaSpecificN[50].Add(1.48601125410632); LaminaSpecificN[50].Add(2.00752396041739);
            LaminaSpecificN[51].Add(0); LaminaSpecificN[51].Add(0); LaminaSpecificN[51].Add(0); LaminaSpecificN[51].Add(0); LaminaSpecificN[51].Add(0); LaminaSpecificN[51].Add(0.996489131201432); LaminaSpecificN[51].Add(1.15913732089482); LaminaSpecificN[51].Add(1.49522221324618); LaminaSpecificN[51].Add(2.02569371184336);
            LaminaSpecificN[52].Add(0); LaminaSpecificN[52].Add(0); LaminaSpecificN[52].Add(0); LaminaSpecificN[52].Add(0); LaminaSpecificN[52].Add(0); LaminaSpecificN[52].Add(0.998054564469651); LaminaSpecificN[52].Add(1.16254913920987); LaminaSpecificN[52].Add(1.50324088218818); LaminaSpecificN[52].Add(2.04255535131633);
            LaminaSpecificN[53].Add(0); LaminaSpecificN[53].Add(0); LaminaSpecificN[53].Add(0); LaminaSpecificN[53].Add(0); LaminaSpecificN[53].Add(0); LaminaSpecificN[53].Add(0.998665764126306); LaminaSpecificN[53].Add(1.16463024783892); LaminaSpecificN[53].Add(1.50908910724913); LaminaSpecificN[53].Add(2.05580541326441);
            LaminaSpecificN[54].Add(0); LaminaSpecificN[54].Add(0); LaminaSpecificN[54].Add(0); LaminaSpecificN[54].Add(0); LaminaSpecificN[54].Add(0); LaminaSpecificN[54].Add(0.999344118900735); LaminaSpecificN[54].Add(1.15087168246119); LaminaSpecificN[54].Add(1.4971709369707); LaminaSpecificN[54].Add(2.06114287771725);
            LaminaSpecificN[55].Add(0); LaminaSpecificN[55].Add(0); LaminaSpecificN[55].Add(0); LaminaSpecificN[55].Add(0); LaminaSpecificN[55].Add(0); LaminaSpecificN[55].Add(0.985666412221715); LaminaSpecificN[55].Add(1.12037981569756); LaminaSpecificN[55].Add(1.44255346203763); LaminaSpecificN[55].Add(2.00455400654666);
            LaminaSpecificN[56].Add(0); LaminaSpecificN[56].Add(0); LaminaSpecificN[56].Add(0); LaminaSpecificN[56].Add(0); LaminaSpecificN[56].Add(0); LaminaSpecificN[56].Add(0.960835530507724); LaminaSpecificN[56].Add(1.07321517803875); LaminaSpecificN[56].Add(1.38549268159687); LaminaSpecificN[56].Add(1.94442616326446);
            LaminaSpecificN[57].Add(0); LaminaSpecificN[57].Add(0); LaminaSpecificN[57].Add(0); LaminaSpecificN[57].Add(0); LaminaSpecificN[57].Add(0); LaminaSpecificN[57].Add(0.92945183053391); LaminaSpecificN[57].Add(1.02241377787869); LaminaSpecificN[57].Add(1.31850419692433); LaminaSpecificN[57].Add(1.86739105584792);
            LaminaSpecificN[58].Add(0); LaminaSpecificN[58].Add(0); LaminaSpecificN[58].Add(0); LaminaSpecificN[58].Add(0); LaminaSpecificN[58].Add(0); LaminaSpecificN[58].Add(0.894613248491803); LaminaSpecificN[58].Add(0.971245679037946); LaminaSpecificN[58].Add(1.25308706311332); LaminaSpecificN[58].Add(1.78665204610776);
            LaminaSpecificN[59].Add(0); LaminaSpecificN[59].Add(0); LaminaSpecificN[59].Add(0); LaminaSpecificN[59].Add(0); LaminaSpecificN[59].Add(0); LaminaSpecificN[59].Add(0); LaminaSpecificN[59].Add(0.919544046354688); LaminaSpecificN[59].Add(1.22980190534927); LaminaSpecificN[59].Add(1.69163202171319);
            LaminaSpecificN[60].Add(0); LaminaSpecificN[60].Add(0); LaminaSpecificN[60].Add(0); LaminaSpecificN[60].Add(0); LaminaSpecificN[60].Add(0); LaminaSpecificN[60].Add(0); LaminaSpecificN[60].Add(0.886037624862106); LaminaSpecificN[60].Add(1.16187785894196); LaminaSpecificN[60].Add(1.63674801613172);
            LaminaSpecificN[61].Add(0); LaminaSpecificN[61].Add(0); LaminaSpecificN[61].Add(0); LaminaSpecificN[61].Add(0); LaminaSpecificN[61].Add(0); LaminaSpecificN[61].Add(0); LaminaSpecificN[61].Add(0.852080323887268); LaminaSpecificN[61].Add(1.0901832534334); LaminaSpecificN[61].Add(1.59046780048194);
            LaminaSpecificN[62].Add(0); LaminaSpecificN[62].Add(0); LaminaSpecificN[62].Add(0); LaminaSpecificN[62].Add(0); LaminaSpecificN[62].Add(0); LaminaSpecificN[62].Add(0); LaminaSpecificN[62].Add(0.81379878215125); LaminaSpecificN[62].Add(1.01120621354563); LaminaSpecificN[62].Add(1.52869399648684);
            LaminaSpecificN[63].Add(0); LaminaSpecificN[63].Add(0); LaminaSpecificN[63].Add(0); LaminaSpecificN[63].Add(0); LaminaSpecificN[63].Add(0); LaminaSpecificN[63].Add(0); LaminaSpecificN[63].Add(0); LaminaSpecificN[63].Add(0.925788738386521); LaminaSpecificN[63].Add(1.43684471916161);
            LaminaSpecificN[64].Add(0); LaminaSpecificN[64].Add(0); LaminaSpecificN[64].Add(0); LaminaSpecificN[64].Add(0); LaminaSpecificN[64].Add(0); LaminaSpecificN[64].Add(0); LaminaSpecificN[64].Add(0); LaminaSpecificN[64].Add(0.826956547962778); LaminaSpecificN[64].Add(1.30457988578248);
            LaminaSpecificN[65].Add(0); LaminaSpecificN[65].Add(0); LaminaSpecificN[65].Add(0); LaminaSpecificN[65].Add(0); LaminaSpecificN[65].Add(0); LaminaSpecificN[65].Add(0); LaminaSpecificN[65].Add(0); LaminaSpecificN[65].Add(0.711466985935067); LaminaSpecificN[65].Add(1.16269776556721);
            LaminaSpecificN[66].Add(0); LaminaSpecificN[66].Add(0); LaminaSpecificN[66].Add(0); LaminaSpecificN[66].Add(0); LaminaSpecificN[66].Add(0); LaminaSpecificN[66].Add(0); LaminaSpecificN[66].Add(0); LaminaSpecificN[66].Add(0); LaminaSpecificN[66].Add(1.14670388631841);
            LaminaSpecificN[67].Add(0); LaminaSpecificN[67].Add(0); LaminaSpecificN[67].Add(0); LaminaSpecificN[67].Add(0); LaminaSpecificN[67].Add(0); LaminaSpecificN[67].Add(0); LaminaSpecificN[67].Add(0); LaminaSpecificN[67].Add(0); LaminaSpecificN[67].Add(1.04286301241026);
            LaminaSpecificN[68].Add(0); LaminaSpecificN[68].Add(0); LaminaSpecificN[68].Add(0); LaminaSpecificN[68].Add(0); LaminaSpecificN[68].Add(0); LaminaSpecificN[68].Add(0); LaminaSpecificN[68].Add(0); LaminaSpecificN[68].Add(0); LaminaSpecificN[68].Add(0.1125);
            #endregion

            List<List<double>> LaminaAreaIndex = new List<List<double>>();
            #region Valorization
            LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>()); LaminaAreaIndex.Add(new List<double>());
            LaminaAreaIndex[0].Add(0);
            LaminaAreaIndex[1].Add(0); LaminaAreaIndex[1].Add(0);
            LaminaAreaIndex[2].Add(0.0153846153846154); LaminaAreaIndex[2].Add(0.0153846153846154);
            LaminaAreaIndex[3].Add(0.0307692307692308); LaminaAreaIndex[3].Add(0.0307692307692308);
            LaminaAreaIndex[4].Add(0.0307692307692308); LaminaAreaIndex[4].Add(0.0369503717072201); LaminaAreaIndex[4].Add(0);
            LaminaAreaIndex[5].Add(0.0307692307692308); LaminaAreaIndex[5].Add(0.0369503717072201); LaminaAreaIndex[5].Add(0.0231959654021323);
            LaminaAreaIndex[6].Add(0.0294185885015326); LaminaAreaIndex[6].Add(0.0353284028575849); LaminaAreaIndex[6].Add(0.0598500499687857); LaminaAreaIndex[6].Add(0);
            LaminaAreaIndex[7].Add(0.0281203548556625); LaminaAreaIndex[7].Add(0.033769370844809); LaminaAreaIndex[7].Add(0.0598500499687857); LaminaAreaIndex[7].Add(0.0491047154099971);
            LaminaAreaIndex[8].Add(0.0281203548556625); LaminaAreaIndex[8].Add(0.033769370844809); LaminaAreaIndex[8].Add(0.0598500499687857); LaminaAreaIndex[8].Add(0.101495570552927);
            LaminaAreaIndex[9].Add(0.00800242717023029); LaminaAreaIndex[9].Add(0.00961001140124891); LaminaAreaIndex[9].Add(0.0598500499687857); LaminaAreaIndex[9].Add(0.135302875735953); LaminaAreaIndex[9].Add(0);
            LaminaAreaIndex[10].Add(0); LaminaAreaIndex[10].Add(0); LaminaAreaIndex[10].Add(0.0257220079373397); LaminaAreaIndex[10].Add(0.193514780650013); LaminaAreaIndex[10].Add(0.0606374009521458);
            LaminaAreaIndex[11].Add(0); LaminaAreaIndex[11].Add(0); LaminaAreaIndex[11].Add(0); LaminaAreaIndex[11].Add(0.228470264851486); LaminaAreaIndex[11].Add(0.0970493636620139);
            LaminaAreaIndex[12].Add(0); LaminaAreaIndex[12].Add(0); LaminaAreaIndex[12].Add(0); LaminaAreaIndex[12].Add(0.228470264851486); LaminaAreaIndex[12].Add(0.0970493636620139);
            LaminaAreaIndex[13].Add(0); LaminaAreaIndex[13].Add(0); LaminaAreaIndex[13].Add(0); LaminaAreaIndex[13].Add(0.228470264851486); LaminaAreaIndex[13].Add(0.0970493636620139);
            LaminaAreaIndex[14].Add(0); LaminaAreaIndex[14].Add(0); LaminaAreaIndex[14].Add(0); LaminaAreaIndex[14].Add(0.228470264851486); LaminaAreaIndex[14].Add(0.129525670978161); LaminaAreaIndex[14].Add(0);
            LaminaAreaIndex[15].Add(0); LaminaAreaIndex[15].Add(0); LaminaAreaIndex[15].Add(0); LaminaAreaIndex[15].Add(0.228470264851486); LaminaAreaIndex[15].Add(0.194791647193763); LaminaAreaIndex[15].Add(0.105492417126326);
            LaminaAreaIndex[16].Add(0); LaminaAreaIndex[16].Add(0); LaminaAreaIndex[16].Add(0); LaminaAreaIndex[16].Add(0.228470264851486); LaminaAreaIndex[16].Add(0.194791647193763); LaminaAreaIndex[16].Add(0.208654236643407);
            LaminaAreaIndex[17].Add(0); LaminaAreaIndex[17].Add(0); LaminaAreaIndex[17].Add(0); LaminaAreaIndex[17].Add(0.228470264851486); LaminaAreaIndex[17].Add(0.194791647193763); LaminaAreaIndex[17].Add(0.342938664232987);
            LaminaAreaIndex[18].Add(0); LaminaAreaIndex[18].Add(0); LaminaAreaIndex[18].Add(0); LaminaAreaIndex[18].Add(0.199867416288524); LaminaAreaIndex[18].Add(0.194791647193763); LaminaAreaIndex[18].Add(0.455017706812656); LaminaAreaIndex[18].Add(0);
            LaminaAreaIndex[19].Add(0); LaminaAreaIndex[19].Add(0); LaminaAreaIndex[19].Add(0); LaminaAreaIndex[19].Add(0.171403514909515); LaminaAreaIndex[19].Add(0.186585829174297); LaminaAreaIndex[19].Add(0.582077519733937); LaminaAreaIndex[19].Add(0.178046896758072);
            LaminaAreaIndex[20].Add(0); LaminaAreaIndex[20].Add(0); LaminaAreaIndex[20].Add(0); LaminaAreaIndex[20].Add(0.120269542267178); LaminaAreaIndex[20].Add(0.186585829174297); LaminaAreaIndex[20].Add(0.582077519733937); LaminaAreaIndex[20].Add(0.308935459567497);
            LaminaAreaIndex[21].Add(0); LaminaAreaIndex[21].Add(0); LaminaAreaIndex[21].Add(0); LaminaAreaIndex[21].Add(0.0844500077944501); LaminaAreaIndex[21].Add(0.186585829174297); LaminaAreaIndex[21].Add(0.582077519733937); LaminaAreaIndex[21].Add(0.426781637945857);
            LaminaAreaIndex[22].Add(0); LaminaAreaIndex[22].Add(0); LaminaAreaIndex[22].Add(0); LaminaAreaIndex[22].Add(0.0725894471466019); LaminaAreaIndex[22].Add(0.186585829174297); LaminaAreaIndex[22].Add(0.582077519733937); LaminaAreaIndex[22].Add(0.618143091158726);
            LaminaAreaIndex[23].Add(0); LaminaAreaIndex[23].Add(0); LaminaAreaIndex[23].Add(0); LaminaAreaIndex[23].Add(0.0565322379158223); LaminaAreaIndex[23].Add(0.186585829174297); LaminaAreaIndex[23].Add(0.582077519733937); LaminaAreaIndex[23].Add(0.86466887761935); LaminaAreaIndex[23].Add(0);
            LaminaAreaIndex[24].Add(0); LaminaAreaIndex[24].Add(0); LaminaAreaIndex[24].Add(0); LaminaAreaIndex[24].Add(0.0244392392492377); LaminaAreaIndex[24].Add(0.179399669474361); LaminaAreaIndex[24].Add(0.559659407741931); LaminaAreaIndex[24].Add(1.02506569169063); LaminaAreaIndex[24].Add(0.20632946414897);
            LaminaAreaIndex[25].Add(0); LaminaAreaIndex[25].Add(0); LaminaAreaIndex[25].Add(0); LaminaAreaIndex[25].Add(0); LaminaAreaIndex[25].Add(0.172517037575482); LaminaAreaIndex[25].Add(0.538188188182172); LaminaAreaIndex[25].Add(1.02506569169063); LaminaAreaIndex[25].Add(0.407440384352653);
            LaminaAreaIndex[26].Add(0); LaminaAreaIndex[26].Add(0); LaminaAreaIndex[26].Add(0); LaminaAreaIndex[26].Add(0); LaminaAreaIndex[26].Add(0.153049529701459); LaminaAreaIndex[26].Add(0.526205004437571); LaminaAreaIndex[26].Add(1.02506569169063); LaminaAreaIndex[26].Add(0.596377691629149);
            LaminaAreaIndex[27].Add(0); LaminaAreaIndex[27].Add(0); LaminaAreaIndex[27].Add(0); LaminaAreaIndex[27].Add(0); LaminaAreaIndex[27].Add(0.136008393080976); LaminaAreaIndex[27].Add(0.505505450656936); LaminaAreaIndex[27].Add(1.02506569169063); LaminaAreaIndex[27].Add(0.796099393061705);
            LaminaAreaIndex[28].Add(0); LaminaAreaIndex[28].Add(0); LaminaAreaIndex[28].Add(0); LaminaAreaIndex[28].Add(0); LaminaAreaIndex[28].Add(0.123061541462962); LaminaAreaIndex[28].Add(0.504615724038059); LaminaAreaIndex[28].Add(1.02506569169063); LaminaAreaIndex[28].Add(1.10128166280763); LaminaAreaIndex[28].Add(0);
            LaminaAreaIndex[29].Add(0); LaminaAreaIndex[29].Add(0); LaminaAreaIndex[29].Add(0); LaminaAreaIndex[29].Add(0); LaminaAreaIndex[29].Add(0.10321708345581); LaminaAreaIndex[29].Add(0.489813333586997); LaminaAreaIndex[29].Add(0.994996429312181); LaminaAreaIndex[29].Add(1.30423794973146); LaminaAreaIndex[29].Add(0.172106931311405);
            LaminaAreaIndex[30].Add(0); LaminaAreaIndex[30].Add(0); LaminaAreaIndex[30].Add(0); LaminaAreaIndex[30].Add(0); LaminaAreaIndex[30].Add(0.0871738270213379); LaminaAreaIndex[30].Add(0.469289540507979); LaminaAreaIndex[30].Add(0.953304830841358); LaminaAreaIndex[30].Add(1.30423794973146); LaminaAreaIndex[30].Add(0.370317854376584);
            LaminaAreaIndex[31].Add(0); LaminaAreaIndex[31].Add(0); LaminaAreaIndex[31].Add(0); LaminaAreaIndex[31].Add(0); LaminaAreaIndex[31].Add(0.0671555206455785); LaminaAreaIndex[31].Add(0.450275834597019); LaminaAreaIndex[31].Add(0.91468079145302); LaminaAreaIndex[31].Add(1.30423794973146); LaminaAreaIndex[31].Add(0.563893361695193);
            LaminaAreaIndex[32].Add(0); LaminaAreaIndex[32].Add(0); LaminaAreaIndex[32].Add(0); LaminaAreaIndex[32].Add(0); LaminaAreaIndex[32].Add(0.0432952156957241); LaminaAreaIndex[32].Add(0.432716814060513); LaminaAreaIndex[32].Add(0.879011769117311); LaminaAreaIndex[32].Add(1.30423794973146); LaminaAreaIndex[32].Add(0.754067675754529);
            LaminaAreaIndex[33].Add(0); LaminaAreaIndex[33].Add(0); LaminaAreaIndex[33].Add(0); LaminaAreaIndex[33].Add(0); LaminaAreaIndex[33].Add(0.0214865182431199); LaminaAreaIndex[33].Add(0.414763967524141); LaminaAreaIndex[33].Add(0.842542736988549); LaminaAreaIndex[33].Add(1.30423794973146); LaminaAreaIndex[33].Add(0.944251740097817);
            LaminaAreaIndex[34].Add(0); LaminaAreaIndex[34].Add(0); LaminaAreaIndex[34].Add(0); LaminaAreaIndex[34].Add(0); LaminaAreaIndex[34].Add(0.00257435376509544); LaminaAreaIndex[34].Add(0.414763967524141); LaminaAreaIndex[34].Add(0.842542736988549); LaminaAreaIndex[34].Add(1.30423794973146); LaminaAreaIndex[34].Add(1.16693961251959);
            LaminaAreaIndex[35].Add(0); LaminaAreaIndex[35].Add(0); LaminaAreaIndex[35].Add(0); LaminaAreaIndex[35].Add(0); LaminaAreaIndex[35].Add(0); LaminaAreaIndex[35].Add(0.414763967524141); LaminaAreaIndex[35].Add(0.842542736988549); LaminaAreaIndex[35].Add(1.30423794973146); LaminaAreaIndex[35].Add(1.42904767822622);
            LaminaAreaIndex[36].Add(0); LaminaAreaIndex[36].Add(0); LaminaAreaIndex[36].Add(0); LaminaAreaIndex[36].Add(0); LaminaAreaIndex[36].Add(0); LaminaAreaIndex[36].Add(0.414763967524141); LaminaAreaIndex[36].Add(0.842542736988549); LaminaAreaIndex[36].Add(1.30423794973146); LaminaAreaIndex[36].Add(1.42904767822622);
            LaminaAreaIndex[37].Add(0); LaminaAreaIndex[37].Add(0); LaminaAreaIndex[37].Add(0); LaminaAreaIndex[37].Add(0); LaminaAreaIndex[37].Add(0); LaminaAreaIndex[37].Add(0.414763967524141); LaminaAreaIndex[37].Add(0.842542736988549); LaminaAreaIndex[37].Add(1.30423794973146); LaminaAreaIndex[37].Add(1.42904767822622);
            LaminaAreaIndex[38].Add(0); LaminaAreaIndex[38].Add(0); LaminaAreaIndex[38].Add(0); LaminaAreaIndex[38].Add(0); LaminaAreaIndex[38].Add(0); LaminaAreaIndex[38].Add(0.414763967524141); LaminaAreaIndex[38].Add(0.842542736988549); LaminaAreaIndex[38].Add(1.30423794973146); LaminaAreaIndex[38].Add(1.42904767822622);
            LaminaAreaIndex[39].Add(0); LaminaAreaIndex[39].Add(0); LaminaAreaIndex[39].Add(0); LaminaAreaIndex[39].Add(0); LaminaAreaIndex[39].Add(0); LaminaAreaIndex[39].Add(0.414763967524141); LaminaAreaIndex[39].Add(0.842542736988549); LaminaAreaIndex[39].Add(1.30423794973146); LaminaAreaIndex[39].Add(1.42904767822622);
            LaminaAreaIndex[40].Add(0); LaminaAreaIndex[40].Add(0); LaminaAreaIndex[40].Add(0); LaminaAreaIndex[40].Add(0); LaminaAreaIndex[40].Add(0); LaminaAreaIndex[40].Add(0.414763967524141); LaminaAreaIndex[40].Add(0.842542736988549); LaminaAreaIndex[40].Add(1.30423794973146); LaminaAreaIndex[40].Add(1.42904767822622);
            LaminaAreaIndex[41].Add(0); LaminaAreaIndex[41].Add(0); LaminaAreaIndex[41].Add(0); LaminaAreaIndex[41].Add(0); LaminaAreaIndex[41].Add(0); LaminaAreaIndex[41].Add(0.414763967524141); LaminaAreaIndex[41].Add(0.842542736988549); LaminaAreaIndex[41].Add(1.30423794973146); LaminaAreaIndex[41].Add(1.42904767822622);
            LaminaAreaIndex[42].Add(0); LaminaAreaIndex[42].Add(0); LaminaAreaIndex[42].Add(0); LaminaAreaIndex[42].Add(0); LaminaAreaIndex[42].Add(0); LaminaAreaIndex[42].Add(0.414763967524141); LaminaAreaIndex[42].Add(0.842542736988549); LaminaAreaIndex[42].Add(1.30423794973146); LaminaAreaIndex[42].Add(1.42904767822622);
            LaminaAreaIndex[43].Add(0); LaminaAreaIndex[43].Add(0); LaminaAreaIndex[43].Add(0); LaminaAreaIndex[43].Add(0); LaminaAreaIndex[43].Add(0); LaminaAreaIndex[43].Add(0.414763967524141); LaminaAreaIndex[43].Add(0.842542736988549); LaminaAreaIndex[43].Add(1.30423794973146); LaminaAreaIndex[43].Add(1.42904767822622);
            LaminaAreaIndex[44].Add(0); LaminaAreaIndex[44].Add(0); LaminaAreaIndex[44].Add(0); LaminaAreaIndex[44].Add(0); LaminaAreaIndex[44].Add(0); LaminaAreaIndex[44].Add(0.414763967524141); LaminaAreaIndex[44].Add(0.842542736988549); LaminaAreaIndex[44].Add(1.30423794973146); LaminaAreaIndex[44].Add(1.42904767822622);
            LaminaAreaIndex[45].Add(0); LaminaAreaIndex[45].Add(0); LaminaAreaIndex[45].Add(0); LaminaAreaIndex[45].Add(0); LaminaAreaIndex[45].Add(0); LaminaAreaIndex[45].Add(0.414763967524141); LaminaAreaIndex[45].Add(0.842542736988549); LaminaAreaIndex[45].Add(1.30423794973146); LaminaAreaIndex[45].Add(1.42904767822622);
            LaminaAreaIndex[46].Add(0); LaminaAreaIndex[46].Add(0); LaminaAreaIndex[46].Add(0); LaminaAreaIndex[46].Add(0); LaminaAreaIndex[46].Add(0); LaminaAreaIndex[46].Add(0.414763967524141); LaminaAreaIndex[46].Add(0.842542736988549); LaminaAreaIndex[46].Add(1.30423794973146); LaminaAreaIndex[46].Add(1.42904767822622);
            LaminaAreaIndex[47].Add(0); LaminaAreaIndex[47].Add(0); LaminaAreaIndex[47].Add(0); LaminaAreaIndex[47].Add(0); LaminaAreaIndex[47].Add(0); LaminaAreaIndex[47].Add(0.414763967524141); LaminaAreaIndex[47].Add(0.842542736988549); LaminaAreaIndex[47].Add(1.30423794973146); LaminaAreaIndex[47].Add(1.42904767822622);
            LaminaAreaIndex[48].Add(0); LaminaAreaIndex[48].Add(0); LaminaAreaIndex[48].Add(0); LaminaAreaIndex[48].Add(0); LaminaAreaIndex[48].Add(0); LaminaAreaIndex[48].Add(0.414763967524141); LaminaAreaIndex[48].Add(0.842542736988549); LaminaAreaIndex[48].Add(1.30423794973146); LaminaAreaIndex[48].Add(1.42904767822622);
            LaminaAreaIndex[49].Add(0); LaminaAreaIndex[49].Add(0); LaminaAreaIndex[49].Add(0); LaminaAreaIndex[49].Add(0); LaminaAreaIndex[49].Add(0); LaminaAreaIndex[49].Add(0.414763967524141); LaminaAreaIndex[49].Add(0.842542736988549); LaminaAreaIndex[49].Add(1.30423794973146); LaminaAreaIndex[49].Add(1.42904767822622);
            LaminaAreaIndex[50].Add(0); LaminaAreaIndex[50].Add(0); LaminaAreaIndex[50].Add(0); LaminaAreaIndex[50].Add(0); LaminaAreaIndex[50].Add(0); LaminaAreaIndex[50].Add(0.366532489466428); LaminaAreaIndex[50].Add(0.842542736988549); LaminaAreaIndex[50].Add(1.30423794973146); LaminaAreaIndex[50].Add(1.42904767822622);
            LaminaAreaIndex[51].Add(0); LaminaAreaIndex[51].Add(0); LaminaAreaIndex[51].Add(0); LaminaAreaIndex[51].Add(0); LaminaAreaIndex[51].Add(0); LaminaAreaIndex[51].Add(0.32744397809005); LaminaAreaIndex[51].Add(0.842542736988549); LaminaAreaIndex[51].Add(1.30423794973146); LaminaAreaIndex[51].Add(1.42904767822622);
            LaminaAreaIndex[52].Add(0); LaminaAreaIndex[52].Add(0); LaminaAreaIndex[52].Add(0); LaminaAreaIndex[52].Add(0); LaminaAreaIndex[52].Add(0); LaminaAreaIndex[52].Add(0.286091975061939); LaminaAreaIndex[52].Add(0.842542736988549); LaminaAreaIndex[52].Add(1.30423794973146); LaminaAreaIndex[52].Add(1.42904767822622);
            LaminaAreaIndex[53].Add(0); LaminaAreaIndex[53].Add(0); LaminaAreaIndex[53].Add(0); LaminaAreaIndex[53].Add(0); LaminaAreaIndex[53].Add(0); LaminaAreaIndex[53].Add(0.249292620666851); LaminaAreaIndex[53].Add(0.842542736988549); LaminaAreaIndex[53].Add(1.30423794973146); LaminaAreaIndex[53].Add(1.42904767822622);
            LaminaAreaIndex[54].Add(0); LaminaAreaIndex[54].Add(0); LaminaAreaIndex[54].Add(0); LaminaAreaIndex[54].Add(0); LaminaAreaIndex[54].Add(0); LaminaAreaIndex[54].Add(0.196019534409003); LaminaAreaIndex[54].Add(0.746417350522841); LaminaAreaIndex[54].Add(1.30423794973146); LaminaAreaIndex[54].Add(1.42904767822622);
            LaminaAreaIndex[55].Add(0); LaminaAreaIndex[55].Add(0); LaminaAreaIndex[55].Add(0); LaminaAreaIndex[55].Add(0); LaminaAreaIndex[55].Add(0); LaminaAreaIndex[55].Add(0.145324822678906); LaminaAreaIndex[55].Add(0.647440414433894); LaminaAreaIndex[55].Add(1.30423794973146); LaminaAreaIndex[55].Add(1.42904767822622);
            LaminaAreaIndex[56].Add(0); LaminaAreaIndex[56].Add(0); LaminaAreaIndex[56].Add(0); LaminaAreaIndex[56].Add(0); LaminaAreaIndex[56].Add(0); LaminaAreaIndex[56].Add(0.0933308949064662); LaminaAreaIndex[56].Add(0.544790318491989); LaminaAreaIndex[56].Add(1.30423794973146); LaminaAreaIndex[56].Add(1.42904767822622);
            LaminaAreaIndex[57].Add(0); LaminaAreaIndex[57].Add(0); LaminaAreaIndex[57].Add(0); LaminaAreaIndex[57].Add(0); LaminaAreaIndex[57].Add(0); LaminaAreaIndex[57].Add(0.0517995952261852); LaminaAreaIndex[57].Add(0.45828044654375); LaminaAreaIndex[57].Add(1.30423794973146); LaminaAreaIndex[57].Add(1.42904767822622);
            LaminaAreaIndex[58].Add(0); LaminaAreaIndex[58].Add(0); LaminaAreaIndex[58].Add(0); LaminaAreaIndex[58].Add(0); LaminaAreaIndex[58].Add(0); LaminaAreaIndex[58].Add(0.0215020698150221); LaminaAreaIndex[58].Add(0.391032490869315); LaminaAreaIndex[58].Add(1.30423794973146); LaminaAreaIndex[58].Add(1.42904767822622);
            LaminaAreaIndex[59].Add(0); LaminaAreaIndex[59].Add(0); LaminaAreaIndex[59].Add(0); LaminaAreaIndex[59].Add(0); LaminaAreaIndex[59].Add(0); LaminaAreaIndex[59].Add(0); LaminaAreaIndex[59].Add(0.329930110434068); LaminaAreaIndex[59].Add(1.24682775594605); LaminaAreaIndex[59].Add(1.42904767822622);
            LaminaAreaIndex[60].Add(0); LaminaAreaIndex[60].Add(0); LaminaAreaIndex[60].Add(0); LaminaAreaIndex[60].Add(0); LaminaAreaIndex[60].Add(0); LaminaAreaIndex[60].Add(0); LaminaAreaIndex[60].Add(0.247208983238449); LaminaAreaIndex[60].Add(1.10212380997858); LaminaAreaIndex[60].Add(1.42904767822622);
            LaminaAreaIndex[61].Add(0); LaminaAreaIndex[61].Add(0); LaminaAreaIndex[61].Add(0); LaminaAreaIndex[61].Add(0); LaminaAreaIndex[61].Add(0); LaminaAreaIndex[61].Add(0); LaminaAreaIndex[61].Add(0.145530126878614); LaminaAreaIndex[61].Add(0.935649923504708); LaminaAreaIndex[61].Add(1.42904767822622);
            LaminaAreaIndex[62].Add(0); LaminaAreaIndex[62].Add(0); LaminaAreaIndex[62].Add(0); LaminaAreaIndex[62].Add(0); LaminaAreaIndex[62].Add(0); LaminaAreaIndex[62].Add(0); LaminaAreaIndex[62].Add(0.036889442166207); LaminaAreaIndex[62].Add(0.757380883232541); LaminaAreaIndex[62].Add(1.42904767822622);
            LaminaAreaIndex[63].Add(0); LaminaAreaIndex[63].Add(0); LaminaAreaIndex[63].Add(0); LaminaAreaIndex[63].Add(0); LaminaAreaIndex[63].Add(0); LaminaAreaIndex[63].Add(0); LaminaAreaIndex[63].Add(0); LaminaAreaIndex[63].Add(0.558534873770577); LaminaAreaIndex[63].Add(1.42904767822622);
            LaminaAreaIndex[64].Add(0); LaminaAreaIndex[64].Add(0); LaminaAreaIndex[64].Add(0); LaminaAreaIndex[64].Add(0); LaminaAreaIndex[64].Add(0); LaminaAreaIndex[64].Add(0); LaminaAreaIndex[64].Add(0); LaminaAreaIndex[64].Add(0.344574353859725); LaminaAreaIndex[64].Add(1.42904767822622);
            LaminaAreaIndex[65].Add(0); LaminaAreaIndex[65].Add(0); LaminaAreaIndex[65].Add(0); LaminaAreaIndex[65].Add(0); LaminaAreaIndex[65].Add(0); LaminaAreaIndex[65].Add(0); LaminaAreaIndex[65].Add(0); LaminaAreaIndex[65].Add(0.125129875590607); LaminaAreaIndex[65].Add(1.39267779540418);
            LaminaAreaIndex[66].Add(0); LaminaAreaIndex[66].Add(0); LaminaAreaIndex[66].Add(0); LaminaAreaIndex[66].Add(0); LaminaAreaIndex[66].Add(0); LaminaAreaIndex[66].Add(0); LaminaAreaIndex[66].Add(0); LaminaAreaIndex[66].Add(0); LaminaAreaIndex[66].Add(1.11142268325494);
            LaminaAreaIndex[67].Add(0); LaminaAreaIndex[67].Add(0); LaminaAreaIndex[67].Add(0); LaminaAreaIndex[67].Add(0); LaminaAreaIndex[67].Add(0); LaminaAreaIndex[67].Add(0); LaminaAreaIndex[67].Add(0); LaminaAreaIndex[67].Add(0); LaminaAreaIndex[67].Add(0.703087596132007);
            LaminaAreaIndex[68].Add(0); LaminaAreaIndex[68].Add(0); LaminaAreaIndex[68].Add(0); LaminaAreaIndex[68].Add(0); LaminaAreaIndex[68].Add(0); LaminaAreaIndex[68].Add(0); LaminaAreaIndex[68].Add(0); LaminaAreaIndex[68].Add(0); LaminaAreaIndex[68].Add(0.160916988826048);
            #endregion

            List<List<double>> SheathAreaIndex = new List<List<double>>();
            #region Valorization
            SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>()); SheathAreaIndex.Add(new List<double>());
            SheathAreaIndex[0].Add(0);
            SheathAreaIndex[1].Add(0); SheathAreaIndex[1].Add(0);
            SheathAreaIndex[2].Add(0); SheathAreaIndex[2].Add(0);
            SheathAreaIndex[3].Add(0); SheathAreaIndex[3].Add(0);
            SheathAreaIndex[4].Add(0.00374636723413139); SheathAreaIndex[4].Add(0); SheathAreaIndex[4].Add(0);
            SheathAreaIndex[5].Add(0.00374636723413139); SheathAreaIndex[5].Add(0); SheathAreaIndex[5].Add(0);
            SheathAreaIndex[6].Add(0.00358191717118742); SheathAreaIndex[6].Add(0); SheathAreaIndex[6].Add(0); SheathAreaIndex[6].Add(0);
            SheathAreaIndex[7].Add(0.00342384822141055); SheathAreaIndex[7].Add(0); SheathAreaIndex[7].Add(0); SheathAreaIndex[7].Add(0);
            SheathAreaIndex[8].Add(0.00342384822141055); SheathAreaIndex[8].Add(0); SheathAreaIndex[8].Add(0); SheathAreaIndex[8].Add(0);
            SheathAreaIndex[9].Add(0.000974351005682389); SheathAreaIndex[9].Add(0); SheathAreaIndex[9].Add(0); SheathAreaIndex[9].Add(0); SheathAreaIndex[9].Add(0);
            SheathAreaIndex[10].Add(0); SheathAreaIndex[10].Add(0); SheathAreaIndex[10].Add(0); SheathAreaIndex[10].Add(0); SheathAreaIndex[10].Add(0);
            SheathAreaIndex[11].Add(0); SheathAreaIndex[11].Add(0); SheathAreaIndex[11].Add(0); SheathAreaIndex[11].Add(0); SheathAreaIndex[11].Add(0);
            SheathAreaIndex[12].Add(0); SheathAreaIndex[12].Add(0); SheathAreaIndex[12].Add(0); SheathAreaIndex[12].Add(0); SheathAreaIndex[12].Add(0);
            SheathAreaIndex[13].Add(0); SheathAreaIndex[13].Add(0); SheathAreaIndex[13].Add(0); SheathAreaIndex[13].Add(0); SheathAreaIndex[13].Add(0);
            SheathAreaIndex[14].Add(0); SheathAreaIndex[14].Add(0); SheathAreaIndex[14].Add(0); SheathAreaIndex[14].Add(0); SheathAreaIndex[14].Add(0); SheathAreaIndex[14].Add(0);
            SheathAreaIndex[15].Add(0); SheathAreaIndex[15].Add(0); SheathAreaIndex[15].Add(0); SheathAreaIndex[15].Add(0); SheathAreaIndex[15].Add(0); SheathAreaIndex[15].Add(0);
            SheathAreaIndex[16].Add(0); SheathAreaIndex[16].Add(0); SheathAreaIndex[16].Add(0); SheathAreaIndex[16].Add(0); SheathAreaIndex[16].Add(0); SheathAreaIndex[16].Add(0);
            SheathAreaIndex[17].Add(0); SheathAreaIndex[17].Add(0); SheathAreaIndex[17].Add(0); SheathAreaIndex[17].Add(0); SheathAreaIndex[17].Add(0); SheathAreaIndex[17].Add(0);
            SheathAreaIndex[18].Add(0); SheathAreaIndex[18].Add(0); SheathAreaIndex[18].Add(0); SheathAreaIndex[18].Add(0); SheathAreaIndex[18].Add(0); SheathAreaIndex[18].Add(0); SheathAreaIndex[18].Add(0);
            SheathAreaIndex[19].Add(0); SheathAreaIndex[19].Add(0); SheathAreaIndex[19].Add(0); SheathAreaIndex[19].Add(0); SheathAreaIndex[19].Add(0); SheathAreaIndex[19].Add(0); SheathAreaIndex[19].Add(0);
            SheathAreaIndex[20].Add(0); SheathAreaIndex[20].Add(0); SheathAreaIndex[20].Add(0); SheathAreaIndex[20].Add(0); SheathAreaIndex[20].Add(0); SheathAreaIndex[20].Add(0.0934061565066114); SheathAreaIndex[20].Add(0);
            SheathAreaIndex[21].Add(0); SheathAreaIndex[21].Add(0); SheathAreaIndex[21].Add(0); SheathAreaIndex[21].Add(0); SheathAreaIndex[21].Add(0); SheathAreaIndex[21].Add(0.0934061565066114); SheathAreaIndex[21].Add(0);
            SheathAreaIndex[22].Add(0); SheathAreaIndex[22].Add(0); SheathAreaIndex[22].Add(0); SheathAreaIndex[22].Add(0); SheathAreaIndex[22].Add(0); SheathAreaIndex[22].Add(0.0934061565066114); SheathAreaIndex[22].Add(0);
            SheathAreaIndex[23].Add(0); SheathAreaIndex[23].Add(0); SheathAreaIndex[23].Add(0); SheathAreaIndex[23].Add(0); SheathAreaIndex[23].Add(0); SheathAreaIndex[23].Add(0.0934061565066114); SheathAreaIndex[23].Add(0); SheathAreaIndex[23].Add(0);
            SheathAreaIndex[24].Add(0); SheathAreaIndex[24].Add(0); SheathAreaIndex[24].Add(0); SheathAreaIndex[24].Add(0); SheathAreaIndex[24].Add(0); SheathAreaIndex[24].Add(0.0934061565066114); SheathAreaIndex[24].Add(0); SheathAreaIndex[24].Add(0);
            SheathAreaIndex[25].Add(0); SheathAreaIndex[25].Add(0); SheathAreaIndex[25].Add(0); SheathAreaIndex[25].Add(0); SheathAreaIndex[25].Add(0); SheathAreaIndex[25].Add(0.0898226482749202); SheathAreaIndex[25].Add(0.15634001187695); SheathAreaIndex[25].Add(0);
            SheathAreaIndex[26].Add(0); SheathAreaIndex[26].Add(0); SheathAreaIndex[26].Add(0); SheathAreaIndex[26].Add(0); SheathAreaIndex[26].Add(0); SheathAreaIndex[26].Add(0.0878226762905095); SheathAreaIndex[26].Add(0.303216476037575); SheathAreaIndex[26].Add(0);
            SheathAreaIndex[27].Add(0); SheathAreaIndex[27].Add(0); SheathAreaIndex[27].Add(0); SheathAreaIndex[27].Add(0); SheathAreaIndex[27].Add(0); SheathAreaIndex[27].Add(0.0843679577004085); SheathAreaIndex[27].Add(0.45847653423047); SheathAreaIndex[27].Add(0);
            SheathAreaIndex[28].Add(0); SheathAreaIndex[28].Add(0); SheathAreaIndex[28].Add(0); SheathAreaIndex[28].Add(0); SheathAreaIndex[28].Add(0); SheathAreaIndex[28].Add(0.0842194639153291); SheathAreaIndex[28].Add(0.45847653423047); SheathAreaIndex[28].Add(0); SheathAreaIndex[28].Add(0);
            SheathAreaIndex[29].Add(0); SheathAreaIndex[29].Add(0); SheathAreaIndex[29].Add(0); SheathAreaIndex[29].Add(0); SheathAreaIndex[29].Add(0); SheathAreaIndex[29].Add(0.0817489713621485); SheathAreaIndex[29].Add(0.445027590115091); SheathAreaIndex[29].Add(0); SheathAreaIndex[29].Add(0);
            SheathAreaIndex[30].Add(0); SheathAreaIndex[30].Add(0); SheathAreaIndex[30].Add(0); SheathAreaIndex[30].Add(0); SheathAreaIndex[30].Add(0); SheathAreaIndex[30].Add(0.0783235869195233); SheathAreaIndex[30].Add(0.426380375864943); SheathAreaIndex[30].Add(0.233739296067428); SheathAreaIndex[30].Add(0);
            SheathAreaIndex[31].Add(0); SheathAreaIndex[31].Add(0); SheathAreaIndex[31].Add(0); SheathAreaIndex[31].Add(0); SheathAreaIndex[31].Add(0); SheathAreaIndex[31].Add(0.0751502333306763); SheathAreaIndex[31].Add(0.409105175006801); SheathAreaIndex[31].Add(0.462012299980881); SheathAreaIndex[31].Add(0);
            SheathAreaIndex[32].Add(0); SheathAreaIndex[32].Add(0); SheathAreaIndex[32].Add(0); SheathAreaIndex[32].Add(0); SheathAreaIndex[32].Add(0); SheathAreaIndex[32].Add(0.0722196641351131); SheathAreaIndex[32].Add(0.393151651371751); SheathAreaIndex[32].Add(0.686274462786702); SheathAreaIndex[32].Add(0);
            SheathAreaIndex[33].Add(0); SheathAreaIndex[33].Add(0); SheathAreaIndex[33].Add(0); SheathAreaIndex[33].Add(0); SheathAreaIndex[33].Add(0); SheathAreaIndex[33].Add(0.0692233660829077); SheathAreaIndex[33].Add(0.376840310944819); SheathAreaIndex[33].Add(0.910548123568881); SheathAreaIndex[33].Add(0);
            SheathAreaIndex[34].Add(0); SheathAreaIndex[34].Add(0); SheathAreaIndex[34].Add(0); SheathAreaIndex[34].Add(0); SheathAreaIndex[34].Add(0); SheathAreaIndex[34].Add(0.0692233660829077); SheathAreaIndex[34].Add(0.376840310944819); SheathAreaIndex[34].Add(0.910548123568881); SheathAreaIndex[34].Add(0);
            SheathAreaIndex[35].Add(0); SheathAreaIndex[35].Add(0); SheathAreaIndex[35].Add(0); SheathAreaIndex[35].Add(0); SheathAreaIndex[35].Add(0); SheathAreaIndex[35].Add(0.0692233660829077); SheathAreaIndex[35].Add(0.376840310944819); SheathAreaIndex[35].Add(0.910548123568881); SheathAreaIndex[35].Add(0);
            SheathAreaIndex[36].Add(0); SheathAreaIndex[36].Add(0); SheathAreaIndex[36].Add(0); SheathAreaIndex[36].Add(0); SheathAreaIndex[36].Add(0); SheathAreaIndex[36].Add(0.0692233660829077); SheathAreaIndex[36].Add(0.376840310944819); SheathAreaIndex[36].Add(0.910548123568881); SheathAreaIndex[36].Add(0.214845848206287);
            SheathAreaIndex[37].Add(0); SheathAreaIndex[37].Add(0); SheathAreaIndex[37].Add(0); SheathAreaIndex[37].Add(0); SheathAreaIndex[37].Add(0); SheathAreaIndex[37].Add(0.0692233660829077); SheathAreaIndex[37].Add(0.376840310944819); SheathAreaIndex[37].Add(0.910548123568881); SheathAreaIndex[37].Add(0.463900733993793);
            SheathAreaIndex[38].Add(0); SheathAreaIndex[38].Add(0); SheathAreaIndex[38].Add(0); SheathAreaIndex[38].Add(0); SheathAreaIndex[38].Add(0); SheathAreaIndex[38].Add(0.0692233660829077); SheathAreaIndex[38].Add(0.376840310944819); SheathAreaIndex[38].Add(0.910548123568881); SheathAreaIndex[38].Add(0.711947977033003);
            SheathAreaIndex[39].Add(0); SheathAreaIndex[39].Add(0); SheathAreaIndex[39].Add(0); SheathAreaIndex[39].Add(0); SheathAreaIndex[39].Add(0); SheathAreaIndex[39].Add(0.0692233660829077); SheathAreaIndex[39].Add(0.376840310944819); SheathAreaIndex[39].Add(0.910548123568881); SheathAreaIndex[39].Add(0.920504732456016);
            SheathAreaIndex[40].Add(0); SheathAreaIndex[40].Add(0); SheathAreaIndex[40].Add(0); SheathAreaIndex[40].Add(0); SheathAreaIndex[40].Add(0); SheathAreaIndex[40].Add(0.0692233660829077); SheathAreaIndex[40].Add(0.376840310944819); SheathAreaIndex[40].Add(0.910548123568881); SheathAreaIndex[40].Add(1.10729645746979);
            SheathAreaIndex[41].Add(0); SheathAreaIndex[41].Add(0); SheathAreaIndex[41].Add(0); SheathAreaIndex[41].Add(0); SheathAreaIndex[41].Add(0); SheathAreaIndex[41].Add(0.0692233660829077); SheathAreaIndex[41].Add(0.376840310944819); SheathAreaIndex[41].Add(0.910548123568881); SheathAreaIndex[41].Add(1.28680412832551);
            SheathAreaIndex[42].Add(0); SheathAreaIndex[42].Add(0); SheathAreaIndex[42].Add(0); SheathAreaIndex[42].Add(0); SheathAreaIndex[42].Add(0); SheathAreaIndex[42].Add(0.0692233660829077); SheathAreaIndex[42].Add(0.376840310944819); SheathAreaIndex[42].Add(0.910548123568881); SheathAreaIndex[42].Add(1.49307590807062);
            SheathAreaIndex[43].Add(0); SheathAreaIndex[43].Add(0); SheathAreaIndex[43].Add(0); SheathAreaIndex[43].Add(0); SheathAreaIndex[43].Add(0); SheathAreaIndex[43].Add(0.0692233660829077); SheathAreaIndex[43].Add(0.376840310944819); SheathAreaIndex[43].Add(0.910548123568881); SheathAreaIndex[43].Add(1.49307590807062);
            SheathAreaIndex[44].Add(0); SheathAreaIndex[44].Add(0); SheathAreaIndex[44].Add(0); SheathAreaIndex[44].Add(0); SheathAreaIndex[44].Add(0); SheathAreaIndex[44].Add(0.0692233660829077); SheathAreaIndex[44].Add(0.376840310944819); SheathAreaIndex[44].Add(0.910548123568881); SheathAreaIndex[44].Add(1.49307590807062);
            SheathAreaIndex[45].Add(0); SheathAreaIndex[45].Add(0); SheathAreaIndex[45].Add(0); SheathAreaIndex[45].Add(0); SheathAreaIndex[45].Add(0); SheathAreaIndex[45].Add(0.0692233660829077); SheathAreaIndex[45].Add(0.376840310944819); SheathAreaIndex[45].Add(0.910548123568881); SheathAreaIndex[45].Add(1.49307590807062);
            SheathAreaIndex[46].Add(0); SheathAreaIndex[46].Add(0); SheathAreaIndex[46].Add(0); SheathAreaIndex[46].Add(0); SheathAreaIndex[46].Add(0); SheathAreaIndex[46].Add(0.0692233660829077); SheathAreaIndex[46].Add(0.376840310944819); SheathAreaIndex[46].Add(0.910548123568881); SheathAreaIndex[46].Add(1.49307590807062);
            SheathAreaIndex[47].Add(0); SheathAreaIndex[47].Add(0); SheathAreaIndex[47].Add(0); SheathAreaIndex[47].Add(0); SheathAreaIndex[47].Add(0); SheathAreaIndex[47].Add(0.0692233660829077); SheathAreaIndex[47].Add(0.376840310944819); SheathAreaIndex[47].Add(0.910548123568881); SheathAreaIndex[47].Add(1.49307590807062);
            SheathAreaIndex[48].Add(0); SheathAreaIndex[48].Add(0); SheathAreaIndex[48].Add(0); SheathAreaIndex[48].Add(0); SheathAreaIndex[48].Add(0); SheathAreaIndex[48].Add(0.0692233660829077); SheathAreaIndex[48].Add(0.376840310944819); SheathAreaIndex[48].Add(0.910548123568881); SheathAreaIndex[48].Add(1.49307590807062);
            SheathAreaIndex[49].Add(0); SheathAreaIndex[49].Add(0); SheathAreaIndex[49].Add(0); SheathAreaIndex[49].Add(0); SheathAreaIndex[49].Add(0); SheathAreaIndex[49].Add(0.0692233660829077); SheathAreaIndex[49].Add(0.376840310944819); SheathAreaIndex[49].Add(0.910548123568881); SheathAreaIndex[49].Add(1.49307590807062);
            SheathAreaIndex[50].Add(0); SheathAreaIndex[50].Add(0); SheathAreaIndex[50].Add(0); SheathAreaIndex[50].Add(0); SheathAreaIndex[50].Add(0); SheathAreaIndex[50].Add(0.0611736184584); SheathAreaIndex[50].Add(0.376840310944819); SheathAreaIndex[50].Add(0.910548123568881); SheathAreaIndex[50].Add(1.49307590807062);
            SheathAreaIndex[51].Add(0); SheathAreaIndex[51].Add(0); SheathAreaIndex[51].Add(0); SheathAreaIndex[51].Add(0); SheathAreaIndex[51].Add(0); SheathAreaIndex[51].Add(0.0546498156584729); SheathAreaIndex[51].Add(0.376840310944819); SheathAreaIndex[51].Add(0.910548123568881); SheathAreaIndex[51].Add(1.49307590807062);
            SheathAreaIndex[52].Add(0); SheathAreaIndex[52].Add(0); SheathAreaIndex[52].Add(0); SheathAreaIndex[52].Add(0); SheathAreaIndex[52].Add(0); SheathAreaIndex[52].Add(0.0477482401408025); SheathAreaIndex[52].Add(0.376840310944819); SheathAreaIndex[52].Add(0.910548123568881); SheathAreaIndex[52].Add(1.49307590807062);
            SheathAreaIndex[53].Add(0); SheathAreaIndex[53].Add(0); SheathAreaIndex[53].Add(0); SheathAreaIndex[53].Add(0); SheathAreaIndex[53].Add(0); SheathAreaIndex[53].Add(0.0416064935563247); SheathAreaIndex[53].Add(0.376840310944819); SheathAreaIndex[53].Add(0.910548123568881); SheathAreaIndex[53].Add(1.49307590807062);
            SheathAreaIndex[54].Add(0); SheathAreaIndex[54].Add(0); SheathAreaIndex[54].Add(0); SheathAreaIndex[54].Add(0); SheathAreaIndex[54].Add(0); SheathAreaIndex[54].Add(0.0327153105193637); SheathAreaIndex[54].Add(0.333846740488202); SheathAreaIndex[54].Add(0.910548123568881); SheathAreaIndex[54].Add(1.49307590807062);
            SheathAreaIndex[55].Add(0); SheathAreaIndex[55].Add(0); SheathAreaIndex[55].Add(0); SheathAreaIndex[55].Add(0); SheathAreaIndex[55].Add(0); SheathAreaIndex[55].Add(0.024254453590282); SheathAreaIndex[55].Add(0.289577770221556); SheathAreaIndex[55].Add(0.910548123568881); SheathAreaIndex[55].Add(1.49307590807062);
            SheathAreaIndex[56].Add(0); SheathAreaIndex[56].Add(0); SheathAreaIndex[56].Add(0); SheathAreaIndex[56].Add(0); SheathAreaIndex[56].Add(0); SheathAreaIndex[56].Add(0.0155767598220298); SheathAreaIndex[56].Add(0.243665922222576); SheathAreaIndex[56].Add(0.885854761955227); SheathAreaIndex[56].Add(1.49307590807062);
            SheathAreaIndex[57].Add(0); SheathAreaIndex[57].Add(0); SheathAreaIndex[57].Add(0); SheathAreaIndex[57].Add(0); SheathAreaIndex[57].Add(0); SheathAreaIndex[57].Add(0.00864526001304573); SheathAreaIndex[57].Add(0.20497303981605); SheathAreaIndex[57].Add(0.855589768727414); SheathAreaIndex[57].Add(1.49307590807062);
            SheathAreaIndex[58].Add(0); SheathAreaIndex[58].Add(0); SheathAreaIndex[58].Add(0); SheathAreaIndex[58].Add(0); SheathAreaIndex[58].Add(0); SheathAreaIndex[58].Add(0.00358865708424606); SheathAreaIndex[58].Add(0.174895348306495); SheathAreaIndex[58].Add(0.823852244349739); SheathAreaIndex[58].Add(1.49307590807062);
            SheathAreaIndex[59].Add(0); SheathAreaIndex[59].Add(0); SheathAreaIndex[59].Add(0); SheathAreaIndex[59].Add(0); SheathAreaIndex[59].Add(0); SheathAreaIndex[59].Add(0); SheathAreaIndex[59].Add(0.147566360669634); SheathAreaIndex[59].Add(0.787587759783562); SheathAreaIndex[59].Add(1.49307590807062);
            SheathAreaIndex[60].Add(0); SheathAreaIndex[60].Add(0); SheathAreaIndex[60].Add(0); SheathAreaIndex[60].Add(0); SheathAreaIndex[60].Add(0); SheathAreaIndex[60].Add(0); SheathAreaIndex[60].Add(0.110568053135085); SheathAreaIndex[60].Add(0.696182145741959); SheathAreaIndex[60].Add(1.49307590807062);
            SheathAreaIndex[61].Add(0); SheathAreaIndex[61].Add(0); SheathAreaIndex[61].Add(0); SheathAreaIndex[61].Add(0); SheathAreaIndex[61].Add(0); SheathAreaIndex[61].Add(0); SheathAreaIndex[61].Add(0.0650906071077096); SheathAreaIndex[61].Add(0.591025042296714); SheathAreaIndex[61].Add(1.49307590807062);
            SheathAreaIndex[62].Add(0); SheathAreaIndex[62].Add(0); SheathAreaIndex[62].Add(0); SheathAreaIndex[62].Add(0); SheathAreaIndex[62].Add(0); SheathAreaIndex[62].Add(0); SheathAreaIndex[62].Add(0.0164993753387293); SheathAreaIndex[62].Add(0.478417255537758); SheathAreaIndex[62].Add(1.49307590807062);
            SheathAreaIndex[63].Add(0); SheathAreaIndex[63].Add(0); SheathAreaIndex[63].Add(0); SheathAreaIndex[63].Add(0); SheathAreaIndex[63].Add(0); SheathAreaIndex[63].Add(0); SheathAreaIndex[63].Add(0); SheathAreaIndex[63].Add(0.35281154746205); SheathAreaIndex[63].Add(1.49307590807062);
            SheathAreaIndex[64].Add(0); SheathAreaIndex[64].Add(0); SheathAreaIndex[64].Add(0); SheathAreaIndex[64].Add(0); SheathAreaIndex[64].Add(0); SheathAreaIndex[64].Add(0); SheathAreaIndex[64].Add(0); SheathAreaIndex[64].Add(0.217658407218672); SheathAreaIndex[64].Add(1.49307590807062);
            SheathAreaIndex[65].Add(0); SheathAreaIndex[65].Add(0); SheathAreaIndex[65].Add(0); SheathAreaIndex[65].Add(0); SheathAreaIndex[65].Add(0); SheathAreaIndex[65].Add(0); SheathAreaIndex[65].Add(0); SheathAreaIndex[65].Add(0.079041197092717); SheathAreaIndex[65].Add(1.45507647904643);
            SheathAreaIndex[66].Add(0); SheathAreaIndex[66].Add(0); SheathAreaIndex[66].Add(0); SheathAreaIndex[66].Add(0); SheathAreaIndex[66].Add(0); SheathAreaIndex[66].Add(0); SheathAreaIndex[66].Add(0); SheathAreaIndex[66].Add(0); SheathAreaIndex[66].Add(1.16121978107189);
            SheathAreaIndex[67].Add(0); SheathAreaIndex[67].Add(0); SheathAreaIndex[67].Add(0); SheathAreaIndex[67].Add(0); SheathAreaIndex[67].Add(0); SheathAreaIndex[67].Add(0); SheathAreaIndex[67].Add(0); SheathAreaIndex[67].Add(0); SheathAreaIndex[67].Add(0.734589312199145);
            SheathAreaIndex[68].Add(0); SheathAreaIndex[68].Add(0); SheathAreaIndex[68].Add(0); SheathAreaIndex[68].Add(0); SheathAreaIndex[68].Add(0); SheathAreaIndex[68].Add(0); SheathAreaIndex[68].Add(0); SheathAreaIndex[68].Add(0); SheathAreaIndex[68].Add(0.168126846204083);
            #endregion

            List<List<double>> TTem = new List<List<double>>();
            #region Valorization
            TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>()); TTem.Add(new List<double>());
            TTem[0].Add(112.330110409888);
            TTem[1].Add(112.330110409888); TTem[1].Add(131.766338184922);
            TTem[2].Add(112.330110409888); TTem[2].Add(131.766338184922);
            TTem[3].Add(112.330110409888); TTem[3].Add(131.766338184922);
            TTem[4].Add(112.330110409888); TTem[4].Add(131.766338184922); TTem[4].Add(173.501821892742);
            TTem[5].Add(112.330110409888); TTem[5].Add(131.766338184922); TTem[5].Add(173.501821892742);
            TTem[6].Add(112.330110409888); TTem[6].Add(131.766338184922); TTem[6].Add(173.501821892742); TTem[6].Add(213.957312379378);
            TTem[7].Add(112.330110409888); TTem[7].Add(131.766338184922); TTem[7].Add(173.501821892742); TTem[7].Add(213.957312379378);
            TTem[8].Add(112.330110409888); TTem[8].Add(131.766338184922); TTem[8].Add(173.501821892742); TTem[8].Add(213.957312379378);
            TTem[9].Add(112.330110409888); TTem[9].Add(131.766338184922); TTem[9].Add(173.501821892742); TTem[9].Add(213.957312379378); TTem[9].Add(280.570678654207);
            TTem[10].Add(112.330110409888); TTem[10].Add(131.766338184922); TTem[10].Add(173.501821892742); TTem[10].Add(213.957312379378); TTem[10].Add(280.570678654207);
            TTem[11].Add(112.330110409888); TTem[11].Add(131.766338184922); TTem[11].Add(173.501821892742); TTem[11].Add(213.957312379378); TTem[11].Add(280.570678654207);
            TTem[12].Add(112.330110409888); TTem[12].Add(131.766338184922); TTem[12].Add(173.501821892742); TTem[12].Add(213.957312379378); TTem[12].Add(280.570678654207);
            TTem[13].Add(112.330110409888); TTem[13].Add(131.766338184922); TTem[13].Add(173.501821892742); TTem[13].Add(213.957312379378); TTem[13].Add(280.570678654207);
            TTem[14].Add(112.330110409888); TTem[14].Add(131.766338184922); TTem[14].Add(173.501821892742); TTem[14].Add(213.957312379378); TTem[14].Add(280.570678654207); TTem[14].Add(378.453152853726);
            TTem[15].Add(112.330110409888); TTem[15].Add(131.766338184922); TTem[15].Add(173.501821892742); TTem[15].Add(213.957312379378); TTem[15].Add(280.570678654207); TTem[15].Add(378.453152853726);
            TTem[16].Add(112.330110409888); TTem[16].Add(131.766338184922); TTem[16].Add(173.501821892742); TTem[16].Add(213.957312379378); TTem[16].Add(280.570678654207); TTem[16].Add(378.453152853726);
            TTem[17].Add(112.330110409888); TTem[17].Add(131.766338184922); TTem[17].Add(173.501821892742); TTem[17].Add(213.957312379378); TTem[17].Add(280.570678654207); TTem[17].Add(378.453152853726);
            TTem[18].Add(112.330110409888); TTem[18].Add(131.766338184922); TTem[18].Add(173.501821892742); TTem[18].Add(213.957312379378); TTem[18].Add(280.570678654207); TTem[18].Add(378.453152853726); TTem[18].Add(467.23305195298);
            TTem[19].Add(112.330110409888); TTem[19].Add(131.766338184922); TTem[19].Add(173.501821892742); TTem[19].Add(213.957312379378); TTem[19].Add(280.570678654207); TTem[19].Add(378.453152853726); TTem[19].Add(467.23305195298);
            TTem[20].Add(112.330110409888); TTem[20].Add(131.766338184922); TTem[20].Add(173.501821892742); TTem[20].Add(213.957312379378); TTem[20].Add(280.570678654207); TTem[20].Add(378.453152853726); TTem[20].Add(467.23305195298);
            TTem[21].Add(112.330110409888); TTem[21].Add(131.766338184922); TTem[21].Add(173.501821892742); TTem[21].Add(213.957312379378); TTem[21].Add(280.570678654207); TTem[21].Add(378.453152853726); TTem[21].Add(467.23305195298);
            TTem[22].Add(112.330110409888); TTem[22].Add(131.766338184922); TTem[22].Add(173.501821892742); TTem[22].Add(213.957312379378); TTem[22].Add(280.570678654207); TTem[22].Add(378.453152853726); TTem[22].Add(467.23305195298);
            TTem[23].Add(112.330110409888); TTem[23].Add(131.766338184922); TTem[23].Add(173.501821892742); TTem[23].Add(213.957312379378); TTem[23].Add(280.570678654207); TTem[23].Add(378.453152853726); TTem[23].Add(467.23305195298); TTem[23].Add(560.665248444002);
            TTem[24].Add(112.330110409888); TTem[24].Add(131.766338184922); TTem[24].Add(173.501821892742); TTem[24].Add(213.957312379378); TTem[24].Add(280.570678654207); TTem[24].Add(378.453152853726); TTem[24].Add(467.23305195298); TTem[24].Add(560.665248444002);
            TTem[25].Add(112.330110409888); TTem[25].Add(131.766338184922); TTem[25].Add(173.501821892742); TTem[25].Add(213.957312379378); TTem[25].Add(280.570678654207); TTem[25].Add(378.453152853726); TTem[25].Add(467.23305195298); TTem[25].Add(560.665248444002);
            TTem[26].Add(112.330110409888); TTem[26].Add(131.766338184922); TTem[26].Add(173.501821892742); TTem[26].Add(213.957312379378); TTem[26].Add(280.570678654207); TTem[26].Add(378.453152853726); TTem[26].Add(467.23305195298); TTem[26].Add(560.665248444002);
            TTem[27].Add(112.330110409888); TTem[27].Add(131.766338184922); TTem[27].Add(173.501821892742); TTem[27].Add(213.957312379378); TTem[27].Add(280.570678654207); TTem[27].Add(378.453152853726); TTem[27].Add(467.23305195298); TTem[27].Add(560.665248444002);
            TTem[28].Add(112.330110409888); TTem[28].Add(131.766338184922); TTem[28].Add(173.501821892742); TTem[28].Add(213.957312379378); TTem[28].Add(280.570678654207); TTem[28].Add(378.453152853726); TTem[28].Add(467.23305195298); TTem[28].Add(560.665248444002); TTem[28].Add(646.389617338974);
            TTem[29].Add(112.330110409888); TTem[29].Add(131.766338184922); TTem[29].Add(173.501821892742); TTem[29].Add(213.957312379378); TTem[29].Add(280.570678654207); TTem[29].Add(378.453152853726); TTem[29].Add(467.23305195298); TTem[29].Add(560.665248444002); TTem[29].Add(646.389617338974);
            TTem[30].Add(112.330110409888); TTem[30].Add(131.766338184922); TTem[30].Add(173.501821892742); TTem[30].Add(213.957312379378); TTem[30].Add(280.570678654207); TTem[30].Add(378.453152853726); TTem[30].Add(467.23305195298); TTem[30].Add(560.665248444002); TTem[30].Add(646.389617338974);
            TTem[31].Add(112.330110409888); TTem[31].Add(131.766338184922); TTem[31].Add(173.501821892742); TTem[31].Add(213.957312379378); TTem[31].Add(280.570678654207); TTem[31].Add(378.453152853726); TTem[31].Add(467.23305195298); TTem[31].Add(560.665248444002); TTem[31].Add(646.389617338974);
            TTem[32].Add(112.330110409888); TTem[32].Add(131.766338184922); TTem[32].Add(173.501821892742); TTem[32].Add(213.957312379378); TTem[32].Add(280.570678654207); TTem[32].Add(378.453152853726); TTem[32].Add(467.23305195298); TTem[32].Add(560.665248444002); TTem[32].Add(646.389617338974);
            TTem[33].Add(112.330110409888); TTem[33].Add(131.766338184922); TTem[33].Add(173.501821892742); TTem[33].Add(213.957312379378); TTem[33].Add(280.570678654207); TTem[33].Add(378.453152853726); TTem[33].Add(467.23305195298); TTem[33].Add(560.665248444002); TTem[33].Add(646.389617338974);
            TTem[34].Add(112.330110409888); TTem[34].Add(131.766338184922); TTem[34].Add(173.501821892742); TTem[34].Add(213.957312379378); TTem[34].Add(280.570678654207); TTem[34].Add(378.453152853726); TTem[34].Add(467.23305195298); TTem[34].Add(560.665248444002); TTem[34].Add(646.389617338974);
            TTem[35].Add(112.330110409888); TTem[35].Add(131.766338184922); TTem[35].Add(173.501821892742); TTem[35].Add(213.957312379378); TTem[35].Add(280.570678654207); TTem[35].Add(378.453152853726); TTem[35].Add(467.23305195298); TTem[35].Add(560.665248444002); TTem[35].Add(646.389617338974);
            TTem[36].Add(112.330110409888); TTem[36].Add(131.766338184922); TTem[36].Add(173.501821892742); TTem[36].Add(213.957312379378); TTem[36].Add(280.570678654207); TTem[36].Add(378.453152853726); TTem[36].Add(467.23305195298); TTem[36].Add(560.665248444002); TTem[36].Add(646.389617338974);
            TTem[37].Add(112.330110409888); TTem[37].Add(131.766338184922); TTem[37].Add(173.501821892742); TTem[37].Add(213.957312379378); TTem[37].Add(280.570678654207); TTem[37].Add(378.453152853726); TTem[37].Add(467.23305195298); TTem[37].Add(560.665248444002); TTem[37].Add(646.389617338974);
            TTem[38].Add(112.330110409888); TTem[38].Add(131.766338184922); TTem[38].Add(173.501821892742); TTem[38].Add(213.957312379378); TTem[38].Add(280.570678654207); TTem[38].Add(378.453152853726); TTem[38].Add(467.23305195298); TTem[38].Add(560.665248444002); TTem[38].Add(646.389617338974);
            TTem[39].Add(112.330110409888); TTem[39].Add(131.766338184922); TTem[39].Add(173.501821892742); TTem[39].Add(213.957312379378); TTem[39].Add(280.570678654207); TTem[39].Add(378.453152853726); TTem[39].Add(467.23305195298); TTem[39].Add(560.665248444002); TTem[39].Add(646.389617338974);
            TTem[40].Add(112.330110409888); TTem[40].Add(131.766338184922); TTem[40].Add(173.501821892742); TTem[40].Add(213.957312379378); TTem[40].Add(280.570678654207); TTem[40].Add(378.453152853726); TTem[40].Add(467.23305195298); TTem[40].Add(560.665248444002); TTem[40].Add(646.389617338974);
            TTem[41].Add(112.330110409888); TTem[41].Add(131.766338184922); TTem[41].Add(173.501821892742); TTem[41].Add(213.957312379378); TTem[41].Add(280.570678654207); TTem[41].Add(378.453152853726); TTem[41].Add(467.23305195298); TTem[41].Add(560.665248444002); TTem[41].Add(646.389617338974);
            TTem[42].Add(112.330110409888); TTem[42].Add(131.766338184922); TTem[42].Add(173.501821892742); TTem[42].Add(213.957312379378); TTem[42].Add(280.570678654207); TTem[42].Add(378.453152853726); TTem[42].Add(467.23305195298); TTem[42].Add(560.665248444002); TTem[42].Add(646.389617338974);
            TTem[43].Add(112.330110409888); TTem[43].Add(131.766338184922); TTem[43].Add(173.501821892742); TTem[43].Add(213.957312379378); TTem[43].Add(280.570678654207); TTem[43].Add(378.453152853726); TTem[43].Add(467.23305195298); TTem[43].Add(560.665248444002); TTem[43].Add(646.389617338974);
            TTem[44].Add(112.330110409888); TTem[44].Add(131.766338184922); TTem[44].Add(173.501821892742); TTem[44].Add(213.957312379378); TTem[44].Add(280.570678654207); TTem[44].Add(378.453152853726); TTem[44].Add(467.23305195298); TTem[44].Add(560.665248444002); TTem[44].Add(646.389617338974);
            TTem[45].Add(112.330110409888); TTem[45].Add(131.766338184922); TTem[45].Add(173.501821892742); TTem[45].Add(213.957312379378); TTem[45].Add(280.570678654207); TTem[45].Add(378.453152853726); TTem[45].Add(467.23305195298); TTem[45].Add(560.665248444002); TTem[45].Add(646.389617338974);
            TTem[46].Add(112.330110409888); TTem[46].Add(131.766338184922); TTem[46].Add(173.501821892742); TTem[46].Add(213.957312379378); TTem[46].Add(280.570678654207); TTem[46].Add(378.453152853726); TTem[46].Add(467.23305195298); TTem[46].Add(560.665248444002); TTem[46].Add(646.389617338974);
            TTem[47].Add(112.330110409888); TTem[47].Add(131.766338184922); TTem[47].Add(173.501821892742); TTem[47].Add(213.957312379378); TTem[47].Add(280.570678654207); TTem[47].Add(378.453152853726); TTem[47].Add(467.23305195298); TTem[47].Add(560.665248444002); TTem[47].Add(646.389617338974);
            TTem[48].Add(112.330110409888); TTem[48].Add(131.766338184922); TTem[48].Add(173.501821892742); TTem[48].Add(213.957312379378); TTem[48].Add(280.570678654207); TTem[48].Add(378.453152853726); TTem[48].Add(467.23305195298); TTem[48].Add(560.665248444002); TTem[48].Add(646.389617338974);
            TTem[49].Add(112.330110409888); TTem[49].Add(131.766338184922); TTem[49].Add(173.501821892742); TTem[49].Add(213.957312379378); TTem[49].Add(280.570678654207); TTem[49].Add(378.453152853726); TTem[49].Add(467.23305195298); TTem[49].Add(560.665248444002); TTem[49].Add(646.389617338974);
            TTem[50].Add(112.330110409888); TTem[50].Add(131.766338184922); TTem[50].Add(173.501821892742); TTem[50].Add(213.957312379378); TTem[50].Add(280.570678654207); TTem[50].Add(378.453152853726); TTem[50].Add(467.23305195298); TTem[50].Add(560.665248444002); TTem[50].Add(646.389617338974);
            TTem[51].Add(112.330110409888); TTem[51].Add(131.766338184922); TTem[51].Add(173.501821892742); TTem[51].Add(213.957312379378); TTem[51].Add(280.570678654207); TTem[51].Add(378.453152853726); TTem[51].Add(467.23305195298); TTem[51].Add(560.665248444002); TTem[51].Add(646.389617338974);
            TTem[52].Add(112.330110409888); TTem[52].Add(131.766338184922); TTem[52].Add(173.501821892742); TTem[52].Add(213.957312379378); TTem[52].Add(280.570678654207); TTem[52].Add(378.453152853726); TTem[52].Add(467.23305195298); TTem[52].Add(560.665248444002); TTem[52].Add(646.389617338974);
            TTem[53].Add(112.330110409888); TTem[53].Add(131.766338184922); TTem[53].Add(173.501821892742); TTem[53].Add(213.957312379378); TTem[53].Add(280.570678654207); TTem[53].Add(378.453152853726); TTem[53].Add(467.23305195298); TTem[53].Add(560.665248444002); TTem[53].Add(646.389617338974);
            TTem[54].Add(112.330110409888); TTem[54].Add(131.766338184922); TTem[54].Add(173.501821892742); TTem[54].Add(213.957312379378); TTem[54].Add(280.570678654207); TTem[54].Add(378.453152853726); TTem[54].Add(467.23305195298); TTem[54].Add(560.665248444002); TTem[54].Add(646.389617338974);
            TTem[55].Add(112.330110409888); TTem[55].Add(131.766338184922); TTem[55].Add(173.501821892742); TTem[55].Add(213.957312379378); TTem[55].Add(280.570678654207); TTem[55].Add(378.453152853726); TTem[55].Add(467.23305195298); TTem[55].Add(560.665248444002); TTem[55].Add(646.389617338974);
            TTem[56].Add(112.330110409888); TTem[56].Add(131.766338184922); TTem[56].Add(173.501821892742); TTem[56].Add(213.957312379378); TTem[56].Add(280.570678654207); TTem[56].Add(378.453152853726); TTem[56].Add(467.23305195298); TTem[56].Add(560.665248444002); TTem[56].Add(646.389617338974);
            TTem[57].Add(112.330110409888); TTem[57].Add(131.766338184922); TTem[57].Add(173.501821892742); TTem[57].Add(213.957312379378); TTem[57].Add(280.570678654207); TTem[57].Add(378.453152853726); TTem[57].Add(467.23305195298); TTem[57].Add(560.665248444002); TTem[57].Add(646.389617338974);
            TTem[58].Add(112.330110409888); TTem[58].Add(131.766338184922); TTem[58].Add(173.501821892742); TTem[58].Add(213.957312379378); TTem[58].Add(280.570678654207); TTem[58].Add(378.453152853726); TTem[58].Add(467.23305195298); TTem[58].Add(560.665248444002); TTem[58].Add(646.389617338974);
            TTem[59].Add(112.330110409888); TTem[59].Add(131.766338184922); TTem[59].Add(173.501821892742); TTem[59].Add(213.957312379378); TTem[59].Add(280.570678654207); TTem[59].Add(378.453152853726); TTem[59].Add(467.23305195298); TTem[59].Add(560.665248444002); TTem[59].Add(646.389617338974);
            TTem[60].Add(112.330110409888); TTem[60].Add(131.766338184922); TTem[60].Add(173.501821892742); TTem[60].Add(213.957312379378); TTem[60].Add(280.570678654207); TTem[60].Add(378.453152853726); TTem[60].Add(467.23305195298); TTem[60].Add(560.665248444002); TTem[60].Add(646.389617338974);
            TTem[61].Add(112.330110409888); TTem[61].Add(131.766338184922); TTem[61].Add(173.501821892742); TTem[61].Add(213.957312379378); TTem[61].Add(280.570678654207); TTem[61].Add(378.453152853726); TTem[61].Add(467.23305195298); TTem[61].Add(560.665248444002); TTem[61].Add(646.389617338974);
            TTem[62].Add(112.330110409888); TTem[62].Add(131.766338184922); TTem[62].Add(173.501821892742); TTem[62].Add(213.957312379378); TTem[62].Add(280.570678654207); TTem[62].Add(378.453152853726); TTem[62].Add(467.23305195298); TTem[62].Add(560.665248444002); TTem[62].Add(646.389617338974);
            TTem[63].Add(112.330110409888); TTem[63].Add(131.766338184922); TTem[63].Add(173.501821892742); TTem[63].Add(213.957312379378); TTem[63].Add(280.570678654207); TTem[63].Add(378.453152853726); TTem[63].Add(467.23305195298); TTem[63].Add(560.665248444002); TTem[63].Add(646.389617338974);
            TTem[64].Add(112.330110409888); TTem[64].Add(131.766338184922); TTem[64].Add(173.501821892742); TTem[64].Add(213.957312379378); TTem[64].Add(280.570678654207); TTem[64].Add(378.453152853726); TTem[64].Add(467.23305195298); TTem[64].Add(560.665248444002); TTem[64].Add(646.389617338974);
            TTem[65].Add(112.330110409888); TTem[65].Add(131.766338184922); TTem[65].Add(173.501821892742); TTem[65].Add(213.957312379378); TTem[65].Add(280.570678654207); TTem[65].Add(378.453152853726); TTem[65].Add(467.23305195298); TTem[65].Add(560.665248444002); TTem[65].Add(646.389617338974);
            TTem[66].Add(112.330110409888); TTem[66].Add(131.766338184922); TTem[66].Add(173.501821892742); TTem[66].Add(213.957312379378); TTem[66].Add(280.570678654207); TTem[66].Add(378.453152853726); TTem[66].Add(467.23305195298); TTem[66].Add(560.665248444002); TTem[66].Add(646.389617338974);
            TTem[67].Add(112.330110409888); TTem[67].Add(131.766338184922); TTem[67].Add(173.501821892742); TTem[67].Add(213.957312379378); TTem[67].Add(280.570678654207); TTem[67].Add(378.453152853726); TTem[67].Add(467.23305195298); TTem[67].Add(560.665248444002); TTem[67].Add(646.389617338974);
            TTem[68].Add(112.330110409888); TTem[68].Add(131.766338184922); TTem[68].Add(173.501821892742); TTem[68].Add(213.957312379378); TTem[68].Add(280.570678654207); TTem[68].Add(378.453152853726); TTem[68].Add(467.23305195298); TTem[68].Add(560.665248444002); TTem[68].Add(646.389617338974);
            #endregion

            List<List<bool>> IsPrematurelyDying=new List<List<bool>>();
            #region Valorization
            IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>()); IsPrematurelyDying.Add(new List<bool>());
            IsPrematurelyDying[0].Add(false);
            IsPrematurelyDying[1].Add(false); IsPrematurelyDying[1].Add(false);
            IsPrematurelyDying[2].Add(false); IsPrematurelyDying[2].Add(false);
            IsPrematurelyDying[3].Add(false); IsPrematurelyDying[3].Add(false);
            IsPrematurelyDying[4].Add(false); IsPrematurelyDying[4].Add(false); IsPrematurelyDying[4].Add(false);
            IsPrematurelyDying[5].Add(false); IsPrematurelyDying[5].Add(false); IsPrematurelyDying[5].Add(false);
            IsPrematurelyDying[6].Add(false); IsPrematurelyDying[6].Add(false); IsPrematurelyDying[6].Add(false); IsPrematurelyDying[6].Add(false);
            IsPrematurelyDying[7].Add(false); IsPrematurelyDying[7].Add(false); IsPrematurelyDying[7].Add(false); IsPrematurelyDying[7].Add(false);
            IsPrematurelyDying[8].Add(false); IsPrematurelyDying[8].Add(false); IsPrematurelyDying[8].Add(false); IsPrematurelyDying[8].Add(false);
            IsPrematurelyDying[9].Add(false); IsPrematurelyDying[9].Add(false); IsPrematurelyDying[9].Add(false); IsPrematurelyDying[9].Add(false); IsPrematurelyDying[9].Add(false);
            IsPrematurelyDying[10].Add(false); IsPrematurelyDying[10].Add(false); IsPrematurelyDying[10].Add(false); IsPrematurelyDying[10].Add(false); IsPrematurelyDying[10].Add(false);
            IsPrematurelyDying[11].Add(false); IsPrematurelyDying[11].Add(false); IsPrematurelyDying[11].Add(false); IsPrematurelyDying[11].Add(false); IsPrematurelyDying[11].Add(false);
            IsPrematurelyDying[12].Add(false); IsPrematurelyDying[12].Add(false); IsPrematurelyDying[12].Add(false); IsPrematurelyDying[12].Add(false); IsPrematurelyDying[12].Add(false);
            IsPrematurelyDying[13].Add(false); IsPrematurelyDying[13].Add(false); IsPrematurelyDying[13].Add(false); IsPrematurelyDying[13].Add(false); IsPrematurelyDying[13].Add(false);
            IsPrematurelyDying[14].Add(false); IsPrematurelyDying[14].Add(false); IsPrematurelyDying[14].Add(false); IsPrematurelyDying[14].Add(false); IsPrematurelyDying[14].Add(false); IsPrematurelyDying[14].Add(false);
            IsPrematurelyDying[15].Add(false); IsPrematurelyDying[15].Add(false); IsPrematurelyDying[15].Add(false); IsPrematurelyDying[15].Add(false); IsPrematurelyDying[15].Add(false); IsPrematurelyDying[15].Add(false);
            IsPrematurelyDying[16].Add(false); IsPrematurelyDying[16].Add(false); IsPrematurelyDying[16].Add(false); IsPrematurelyDying[16].Add(false); IsPrematurelyDying[16].Add(false); IsPrematurelyDying[16].Add(false);
            IsPrematurelyDying[17].Add(false); IsPrematurelyDying[17].Add(false); IsPrematurelyDying[17].Add(false); IsPrematurelyDying[17].Add(false); IsPrematurelyDying[17].Add(false); IsPrematurelyDying[17].Add(false);
            IsPrematurelyDying[18].Add(false); IsPrematurelyDying[18].Add(false); IsPrematurelyDying[18].Add(false); IsPrematurelyDying[18].Add(false); IsPrematurelyDying[18].Add(false); IsPrematurelyDying[18].Add(false); IsPrematurelyDying[18].Add(false);
            IsPrematurelyDying[19].Add(false); IsPrematurelyDying[19].Add(false); IsPrematurelyDying[19].Add(false); IsPrematurelyDying[19].Add(false); IsPrematurelyDying[19].Add(false); IsPrematurelyDying[19].Add(false); IsPrematurelyDying[19].Add(false);
            IsPrematurelyDying[20].Add(false); IsPrematurelyDying[20].Add(false); IsPrematurelyDying[20].Add(false); IsPrematurelyDying[20].Add(false); IsPrematurelyDying[20].Add(false); IsPrematurelyDying[20].Add(false); IsPrematurelyDying[20].Add(false);
            IsPrematurelyDying[21].Add(false); IsPrematurelyDying[21].Add(false); IsPrematurelyDying[21].Add(false); IsPrematurelyDying[21].Add(false); IsPrematurelyDying[21].Add(false); IsPrematurelyDying[21].Add(false); IsPrematurelyDying[21].Add(false);
            IsPrematurelyDying[22].Add(false); IsPrematurelyDying[22].Add(false); IsPrematurelyDying[22].Add(false); IsPrematurelyDying[22].Add(false); IsPrematurelyDying[22].Add(false); IsPrematurelyDying[22].Add(false); IsPrematurelyDying[22].Add(false);
            IsPrematurelyDying[23].Add(false); IsPrematurelyDying[23].Add(false); IsPrematurelyDying[23].Add(false); IsPrematurelyDying[23].Add(false); IsPrematurelyDying[23].Add(false); IsPrematurelyDying[23].Add(false); IsPrematurelyDying[23].Add(false); IsPrematurelyDying[23].Add(false);
            IsPrematurelyDying[24].Add(false); IsPrematurelyDying[24].Add(false); IsPrematurelyDying[24].Add(false); IsPrematurelyDying[24].Add(false); IsPrematurelyDying[24].Add(false); IsPrematurelyDying[24].Add(false); IsPrematurelyDying[24].Add(false); IsPrematurelyDying[24].Add(false);
            IsPrematurelyDying[25].Add(false); IsPrematurelyDying[25].Add(false); IsPrematurelyDying[25].Add(false); IsPrematurelyDying[25].Add(false); IsPrematurelyDying[25].Add(false); IsPrematurelyDying[25].Add(false); IsPrematurelyDying[25].Add(false); IsPrematurelyDying[25].Add(false);
            IsPrematurelyDying[26].Add(false); IsPrematurelyDying[26].Add(false); IsPrematurelyDying[26].Add(false); IsPrematurelyDying[26].Add(false); IsPrematurelyDying[26].Add(false); IsPrematurelyDying[26].Add(false); IsPrematurelyDying[26].Add(false); IsPrematurelyDying[26].Add(false);
            IsPrematurelyDying[27].Add(false); IsPrematurelyDying[27].Add(false); IsPrematurelyDying[27].Add(false); IsPrematurelyDying[27].Add(false); IsPrematurelyDying[27].Add(false); IsPrematurelyDying[27].Add(false); IsPrematurelyDying[27].Add(false); IsPrematurelyDying[27].Add(false);
            IsPrematurelyDying[28].Add(false); IsPrematurelyDying[28].Add(false); IsPrematurelyDying[28].Add(false); IsPrematurelyDying[28].Add(false); IsPrematurelyDying[28].Add(false); IsPrematurelyDying[28].Add(false); IsPrematurelyDying[28].Add(false); IsPrematurelyDying[28].Add(false); IsPrematurelyDying[28].Add(false);
            IsPrematurelyDying[29].Add(false); IsPrematurelyDying[29].Add(false); IsPrematurelyDying[29].Add(false); IsPrematurelyDying[29].Add(false); IsPrematurelyDying[29].Add(false); IsPrematurelyDying[29].Add(false); IsPrematurelyDying[29].Add(false); IsPrematurelyDying[29].Add(false); IsPrematurelyDying[29].Add(false);
            IsPrematurelyDying[30].Add(false); IsPrematurelyDying[30].Add(false); IsPrematurelyDying[30].Add(false); IsPrematurelyDying[30].Add(false); IsPrematurelyDying[30].Add(false); IsPrematurelyDying[30].Add(false); IsPrematurelyDying[30].Add(false); IsPrematurelyDying[30].Add(false); IsPrematurelyDying[30].Add(false);
            IsPrematurelyDying[31].Add(false); IsPrematurelyDying[31].Add(false); IsPrematurelyDying[31].Add(false); IsPrematurelyDying[31].Add(false); IsPrematurelyDying[31].Add(false); IsPrematurelyDying[31].Add(false); IsPrematurelyDying[31].Add(false); IsPrematurelyDying[31].Add(false); IsPrematurelyDying[31].Add(false);
            IsPrematurelyDying[32].Add(false); IsPrematurelyDying[32].Add(false); IsPrematurelyDying[32].Add(false); IsPrematurelyDying[32].Add(false); IsPrematurelyDying[32].Add(false); IsPrematurelyDying[32].Add(false); IsPrematurelyDying[32].Add(false); IsPrematurelyDying[32].Add(false); IsPrematurelyDying[32].Add(false);
            IsPrematurelyDying[33].Add(false); IsPrematurelyDying[33].Add(false); IsPrematurelyDying[33].Add(false); IsPrematurelyDying[33].Add(false); IsPrematurelyDying[33].Add(false); IsPrematurelyDying[33].Add(false); IsPrematurelyDying[33].Add(false); IsPrematurelyDying[33].Add(false); IsPrematurelyDying[33].Add(false);
            IsPrematurelyDying[34].Add(false); IsPrematurelyDying[34].Add(false); IsPrematurelyDying[34].Add(false); IsPrematurelyDying[34].Add(false); IsPrematurelyDying[34].Add(false); IsPrematurelyDying[34].Add(false); IsPrematurelyDying[34].Add(false); IsPrematurelyDying[34].Add(false); IsPrematurelyDying[34].Add(false);
            IsPrematurelyDying[35].Add(false); IsPrematurelyDying[35].Add(false); IsPrematurelyDying[35].Add(false); IsPrematurelyDying[35].Add(false); IsPrematurelyDying[35].Add(false); IsPrematurelyDying[35].Add(false); IsPrematurelyDying[35].Add(false); IsPrematurelyDying[35].Add(false); IsPrematurelyDying[35].Add(false);
            IsPrematurelyDying[36].Add(false); IsPrematurelyDying[36].Add(false); IsPrematurelyDying[36].Add(false); IsPrematurelyDying[36].Add(false); IsPrematurelyDying[36].Add(false); IsPrematurelyDying[36].Add(false); IsPrematurelyDying[36].Add(false); IsPrematurelyDying[36].Add(false); IsPrematurelyDying[36].Add(false);
            IsPrematurelyDying[37].Add(false); IsPrematurelyDying[37].Add(false); IsPrematurelyDying[37].Add(false); IsPrematurelyDying[37].Add(false); IsPrematurelyDying[37].Add(false); IsPrematurelyDying[37].Add(false); IsPrematurelyDying[37].Add(false); IsPrematurelyDying[37].Add(false); IsPrematurelyDying[37].Add(false);
            IsPrematurelyDying[38].Add(false); IsPrematurelyDying[38].Add(false); IsPrematurelyDying[38].Add(false); IsPrematurelyDying[38].Add(false); IsPrematurelyDying[38].Add(false); IsPrematurelyDying[38].Add(false); IsPrematurelyDying[38].Add(false); IsPrematurelyDying[38].Add(false); IsPrematurelyDying[38].Add(false);
            IsPrematurelyDying[39].Add(false); IsPrematurelyDying[39].Add(false); IsPrematurelyDying[39].Add(false); IsPrematurelyDying[39].Add(false); IsPrematurelyDying[39].Add(false); IsPrematurelyDying[39].Add(false); IsPrematurelyDying[39].Add(false); IsPrematurelyDying[39].Add(false); IsPrematurelyDying[39].Add(false);
            IsPrematurelyDying[40].Add(false); IsPrematurelyDying[40].Add(false); IsPrematurelyDying[40].Add(false); IsPrematurelyDying[40].Add(false); IsPrematurelyDying[40].Add(false); IsPrematurelyDying[40].Add(false); IsPrematurelyDying[40].Add(false); IsPrematurelyDying[40].Add(false); IsPrematurelyDying[40].Add(false);
            IsPrematurelyDying[41].Add(false); IsPrematurelyDying[41].Add(false); IsPrematurelyDying[41].Add(false); IsPrematurelyDying[41].Add(false); IsPrematurelyDying[41].Add(false); IsPrematurelyDying[41].Add(false); IsPrematurelyDying[41].Add(false); IsPrematurelyDying[41].Add(false); IsPrematurelyDying[41].Add(false);
            IsPrematurelyDying[42].Add(false); IsPrematurelyDying[42].Add(false); IsPrematurelyDying[42].Add(false); IsPrematurelyDying[42].Add(false); IsPrematurelyDying[42].Add(false); IsPrematurelyDying[42].Add(false); IsPrematurelyDying[42].Add(false); IsPrematurelyDying[42].Add(false); IsPrematurelyDying[42].Add(false);
            IsPrematurelyDying[43].Add(false); IsPrematurelyDying[43].Add(false); IsPrematurelyDying[43].Add(false); IsPrematurelyDying[43].Add(false); IsPrematurelyDying[43].Add(false); IsPrematurelyDying[43].Add(false); IsPrematurelyDying[43].Add(false); IsPrematurelyDying[43].Add(false); IsPrematurelyDying[43].Add(false);
            IsPrematurelyDying[44].Add(false); IsPrematurelyDying[44].Add(false); IsPrematurelyDying[44].Add(false); IsPrematurelyDying[44].Add(false); IsPrematurelyDying[44].Add(false); IsPrematurelyDying[44].Add(false); IsPrematurelyDying[44].Add(false); IsPrematurelyDying[44].Add(false); IsPrematurelyDying[44].Add(false);
            IsPrematurelyDying[45].Add(false); IsPrematurelyDying[45].Add(false); IsPrematurelyDying[45].Add(false); IsPrematurelyDying[45].Add(false); IsPrematurelyDying[45].Add(false); IsPrematurelyDying[45].Add(false); IsPrematurelyDying[45].Add(false); IsPrematurelyDying[45].Add(false); IsPrematurelyDying[45].Add(false);
            IsPrematurelyDying[46].Add(false); IsPrematurelyDying[46].Add(false); IsPrematurelyDying[46].Add(false); IsPrematurelyDying[46].Add(false); IsPrematurelyDying[46].Add(false); IsPrematurelyDying[46].Add(false); IsPrematurelyDying[46].Add(false); IsPrematurelyDying[46].Add(false); IsPrematurelyDying[46].Add(false);
            IsPrematurelyDying[47].Add(false); IsPrematurelyDying[47].Add(false); IsPrematurelyDying[47].Add(false); IsPrematurelyDying[47].Add(false); IsPrematurelyDying[47].Add(false); IsPrematurelyDying[47].Add(false); IsPrematurelyDying[47].Add(false); IsPrematurelyDying[47].Add(false); IsPrematurelyDying[47].Add(false);
            IsPrematurelyDying[48].Add(false); IsPrematurelyDying[48].Add(false); IsPrematurelyDying[48].Add(false); IsPrematurelyDying[48].Add(false); IsPrematurelyDying[48].Add(false); IsPrematurelyDying[48].Add(false); IsPrematurelyDying[48].Add(false); IsPrematurelyDying[48].Add(false); IsPrematurelyDying[48].Add(false);
            IsPrematurelyDying[49].Add(false); IsPrematurelyDying[49].Add(false); IsPrematurelyDying[49].Add(false); IsPrematurelyDying[49].Add(false); IsPrematurelyDying[49].Add(false); IsPrematurelyDying[49].Add(false); IsPrematurelyDying[49].Add(false); IsPrematurelyDying[49].Add(false); IsPrematurelyDying[49].Add(false);
            IsPrematurelyDying[50].Add(false); IsPrematurelyDying[50].Add(false); IsPrematurelyDying[50].Add(false); IsPrematurelyDying[50].Add(false); IsPrematurelyDying[50].Add(false); IsPrematurelyDying[50].Add(false); IsPrematurelyDying[50].Add(false); IsPrematurelyDying[50].Add(false); IsPrematurelyDying[50].Add(false);
            IsPrematurelyDying[51].Add(false); IsPrematurelyDying[51].Add(false); IsPrematurelyDying[51].Add(false); IsPrematurelyDying[51].Add(false); IsPrematurelyDying[51].Add(false); IsPrematurelyDying[51].Add(false); IsPrematurelyDying[51].Add(false); IsPrematurelyDying[51].Add(false); IsPrematurelyDying[51].Add(false);
            IsPrematurelyDying[52].Add(false); IsPrematurelyDying[52].Add(false); IsPrematurelyDying[52].Add(false); IsPrematurelyDying[52].Add(false); IsPrematurelyDying[52].Add(false); IsPrematurelyDying[52].Add(false); IsPrematurelyDying[52].Add(false); IsPrematurelyDying[52].Add(false); IsPrematurelyDying[52].Add(false);
            IsPrematurelyDying[53].Add(false); IsPrematurelyDying[53].Add(false); IsPrematurelyDying[53].Add(false); IsPrematurelyDying[53].Add(false); IsPrematurelyDying[53].Add(false); IsPrematurelyDying[53].Add(false); IsPrematurelyDying[53].Add(false); IsPrematurelyDying[53].Add(false); IsPrematurelyDying[53].Add(false);
            IsPrematurelyDying[54].Add(false); IsPrematurelyDying[54].Add(false); IsPrematurelyDying[54].Add(false); IsPrematurelyDying[54].Add(false); IsPrematurelyDying[54].Add(false); IsPrematurelyDying[54].Add(false); IsPrematurelyDying[54].Add(false); IsPrematurelyDying[54].Add(false); IsPrematurelyDying[54].Add(false);
            IsPrematurelyDying[55].Add(false); IsPrematurelyDying[55].Add(false); IsPrematurelyDying[55].Add(false); IsPrematurelyDying[55].Add(false); IsPrematurelyDying[55].Add(false); IsPrematurelyDying[55].Add(false); IsPrematurelyDying[55].Add(false); IsPrematurelyDying[55].Add(false); IsPrematurelyDying[55].Add(false);
            IsPrematurelyDying[56].Add(false); IsPrematurelyDying[56].Add(false); IsPrematurelyDying[56].Add(false); IsPrematurelyDying[56].Add(false); IsPrematurelyDying[56].Add(false); IsPrematurelyDying[56].Add(false); IsPrematurelyDying[56].Add(false); IsPrematurelyDying[56].Add(false); IsPrematurelyDying[56].Add(false);
            IsPrematurelyDying[57].Add(false); IsPrematurelyDying[57].Add(false); IsPrematurelyDying[57].Add(false); IsPrematurelyDying[57].Add(false); IsPrematurelyDying[57].Add(false); IsPrematurelyDying[57].Add(false); IsPrematurelyDying[57].Add(false); IsPrematurelyDying[57].Add(false); IsPrematurelyDying[57].Add(false);
            IsPrematurelyDying[58].Add(false); IsPrematurelyDying[58].Add(false); IsPrematurelyDying[58].Add(false); IsPrematurelyDying[58].Add(false); IsPrematurelyDying[58].Add(false); IsPrematurelyDying[58].Add(false); IsPrematurelyDying[58].Add(false); IsPrematurelyDying[58].Add(false); IsPrematurelyDying[58].Add(false);
            IsPrematurelyDying[59].Add(false); IsPrematurelyDying[59].Add(false); IsPrematurelyDying[59].Add(false); IsPrematurelyDying[59].Add(false); IsPrematurelyDying[59].Add(false); IsPrematurelyDying[59].Add(false); IsPrematurelyDying[59].Add(false); IsPrematurelyDying[59].Add(false); IsPrematurelyDying[59].Add(false);
            IsPrematurelyDying[60].Add(false); IsPrematurelyDying[60].Add(false); IsPrematurelyDying[60].Add(false); IsPrematurelyDying[60].Add(false); IsPrematurelyDying[60].Add(false); IsPrematurelyDying[60].Add(false); IsPrematurelyDying[60].Add(false); IsPrematurelyDying[60].Add(false); IsPrematurelyDying[60].Add(false);
            IsPrematurelyDying[61].Add(false); IsPrematurelyDying[61].Add(false); IsPrematurelyDying[61].Add(false); IsPrematurelyDying[61].Add(false); IsPrematurelyDying[61].Add(false); IsPrematurelyDying[61].Add(false); IsPrematurelyDying[61].Add(false); IsPrematurelyDying[61].Add(false); IsPrematurelyDying[61].Add(false);
            IsPrematurelyDying[62].Add(false); IsPrematurelyDying[62].Add(false); IsPrematurelyDying[62].Add(false); IsPrematurelyDying[62].Add(false); IsPrematurelyDying[62].Add(false); IsPrematurelyDying[62].Add(false); IsPrematurelyDying[62].Add(false); IsPrematurelyDying[62].Add(false); IsPrematurelyDying[62].Add(false);
            IsPrematurelyDying[63].Add(false); IsPrematurelyDying[63].Add(false); IsPrematurelyDying[63].Add(false); IsPrematurelyDying[63].Add(false); IsPrematurelyDying[63].Add(false); IsPrematurelyDying[63].Add(false); IsPrematurelyDying[63].Add(false); IsPrematurelyDying[63].Add(false); IsPrematurelyDying[63].Add(false);
            IsPrematurelyDying[64].Add(false); IsPrematurelyDying[64].Add(false); IsPrematurelyDying[64].Add(false); IsPrematurelyDying[64].Add(false); IsPrematurelyDying[64].Add(false); IsPrematurelyDying[64].Add(false); IsPrematurelyDying[64].Add(false); IsPrematurelyDying[64].Add(false); IsPrematurelyDying[64].Add(false);
            IsPrematurelyDying[65].Add(false); IsPrematurelyDying[65].Add(false); IsPrematurelyDying[65].Add(false); IsPrematurelyDying[65].Add(false); IsPrematurelyDying[65].Add(false); IsPrematurelyDying[65].Add(false); IsPrematurelyDying[65].Add(false); IsPrematurelyDying[65].Add(false); IsPrematurelyDying[65].Add(false);
            IsPrematurelyDying[66].Add(false); IsPrematurelyDying[66].Add(false); IsPrematurelyDying[66].Add(false); IsPrematurelyDying[66].Add(false); IsPrematurelyDying[66].Add(false); IsPrematurelyDying[66].Add(false); IsPrematurelyDying[66].Add(false); IsPrematurelyDying[66].Add(false); IsPrematurelyDying[66].Add(false);
            IsPrematurelyDying[67].Add(false); IsPrematurelyDying[67].Add(false); IsPrematurelyDying[67].Add(false); IsPrematurelyDying[67].Add(false); IsPrematurelyDying[67].Add(false); IsPrematurelyDying[67].Add(false); IsPrematurelyDying[67].Add(false); IsPrematurelyDying[67].Add(false); IsPrematurelyDying[67].Add(false);
            IsPrematurelyDying[68].Add(false); IsPrematurelyDying[68].Add(false); IsPrematurelyDying[68].Add(false); IsPrematurelyDying[68].Add(false); IsPrematurelyDying[68].Add(false); IsPrematurelyDying[68].Add(false); IsPrematurelyDying[68].Add(false); IsPrematurelyDying[68].Add(false); IsPrematurelyDying[68].Add(false);
            #endregion
            
            List<List<bool>> IsSmallPhytomer = new List<List<bool>>();
            #region Valorization
            IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>()); IsSmallPhytomer.Add(new List<bool>());
            IsSmallPhytomer[0].Add(true);
            IsSmallPhytomer[1].Add(true); IsSmallPhytomer[1].Add(true);
            IsSmallPhytomer[2].Add(true); IsSmallPhytomer[2].Add(true);
            IsSmallPhytomer[3].Add(true); IsSmallPhytomer[3].Add(true);
            IsSmallPhytomer[4].Add(true); IsSmallPhytomer[4].Add(true); IsSmallPhytomer[4].Add(true);
            IsSmallPhytomer[5].Add(true); IsSmallPhytomer[5].Add(true); IsSmallPhytomer[5].Add(true);
            IsSmallPhytomer[6].Add(true); IsSmallPhytomer[6].Add(true); IsSmallPhytomer[6].Add(true); IsSmallPhytomer[6].Add(true);
            IsSmallPhytomer[7].Add(true); IsSmallPhytomer[7].Add(true); IsSmallPhytomer[7].Add(true); IsSmallPhytomer[7].Add(true);
            IsSmallPhytomer[8].Add(true); IsSmallPhytomer[8].Add(true); IsSmallPhytomer[8].Add(true); IsSmallPhytomer[8].Add(true);
            IsSmallPhytomer[9].Add(true); IsSmallPhytomer[9].Add(true); IsSmallPhytomer[9].Add(true); IsSmallPhytomer[9].Add(true); IsSmallPhytomer[9].Add(true);
            IsSmallPhytomer[10].Add(true); IsSmallPhytomer[10].Add(true); IsSmallPhytomer[10].Add(true); IsSmallPhytomer[10].Add(true); IsSmallPhytomer[10].Add(true);
            IsSmallPhytomer[11].Add(true); IsSmallPhytomer[11].Add(true); IsSmallPhytomer[11].Add(true); IsSmallPhytomer[11].Add(true); IsSmallPhytomer[11].Add(true);
            IsSmallPhytomer[12].Add(true); IsSmallPhytomer[12].Add(true); IsSmallPhytomer[12].Add(true); IsSmallPhytomer[12].Add(true); IsSmallPhytomer[12].Add(true);
            IsSmallPhytomer[13].Add(true); IsSmallPhytomer[13].Add(true); IsSmallPhytomer[13].Add(true); IsSmallPhytomer[13].Add(true); IsSmallPhytomer[13].Add(true);
            IsSmallPhytomer[14].Add(true); IsSmallPhytomer[14].Add(true); IsSmallPhytomer[14].Add(true); IsSmallPhytomer[14].Add(true); IsSmallPhytomer[14].Add(true); IsSmallPhytomer[14].Add(false);
            IsSmallPhytomer[15].Add(true); IsSmallPhytomer[15].Add(true); IsSmallPhytomer[15].Add(true); IsSmallPhytomer[15].Add(true); IsSmallPhytomer[15].Add(true); IsSmallPhytomer[15].Add(false);
            IsSmallPhytomer[16].Add(true); IsSmallPhytomer[16].Add(true); IsSmallPhytomer[16].Add(true); IsSmallPhytomer[16].Add(true); IsSmallPhytomer[16].Add(true); IsSmallPhytomer[16].Add(false);
            IsSmallPhytomer[17].Add(true); IsSmallPhytomer[17].Add(true); IsSmallPhytomer[17].Add(true); IsSmallPhytomer[17].Add(true); IsSmallPhytomer[17].Add(true); IsSmallPhytomer[17].Add(false);
            IsSmallPhytomer[18].Add(true); IsSmallPhytomer[18].Add(true); IsSmallPhytomer[18].Add(true); IsSmallPhytomer[18].Add(true); IsSmallPhytomer[18].Add(true); IsSmallPhytomer[18].Add(false); IsSmallPhytomer[18].Add(false);
            IsSmallPhytomer[19].Add(true); IsSmallPhytomer[19].Add(true); IsSmallPhytomer[19].Add(true); IsSmallPhytomer[19].Add(true); IsSmallPhytomer[19].Add(true); IsSmallPhytomer[19].Add(false); IsSmallPhytomer[19].Add(false);
            IsSmallPhytomer[20].Add(true); IsSmallPhytomer[20].Add(true); IsSmallPhytomer[20].Add(true); IsSmallPhytomer[20].Add(true); IsSmallPhytomer[20].Add(true); IsSmallPhytomer[20].Add(false); IsSmallPhytomer[20].Add(false);
            IsSmallPhytomer[21].Add(true); IsSmallPhytomer[21].Add(true); IsSmallPhytomer[21].Add(true); IsSmallPhytomer[21].Add(true); IsSmallPhytomer[21].Add(true); IsSmallPhytomer[21].Add(false); IsSmallPhytomer[21].Add(false);
            IsSmallPhytomer[22].Add(true); IsSmallPhytomer[22].Add(true); IsSmallPhytomer[22].Add(true); IsSmallPhytomer[22].Add(true); IsSmallPhytomer[22].Add(true); IsSmallPhytomer[22].Add(false); IsSmallPhytomer[22].Add(false);
            IsSmallPhytomer[23].Add(true); IsSmallPhytomer[23].Add(true); IsSmallPhytomer[23].Add(true); IsSmallPhytomer[23].Add(true); IsSmallPhytomer[23].Add(true); IsSmallPhytomer[23].Add(false); IsSmallPhytomer[23].Add(false); IsSmallPhytomer[23].Add(false);
            IsSmallPhytomer[24].Add(true); IsSmallPhytomer[24].Add(true); IsSmallPhytomer[24].Add(true); IsSmallPhytomer[24].Add(true); IsSmallPhytomer[24].Add(true); IsSmallPhytomer[24].Add(false); IsSmallPhytomer[24].Add(false); IsSmallPhytomer[24].Add(false);
            IsSmallPhytomer[25].Add(true); IsSmallPhytomer[25].Add(true); IsSmallPhytomer[25].Add(true); IsSmallPhytomer[25].Add(true); IsSmallPhytomer[25].Add(true); IsSmallPhytomer[25].Add(false); IsSmallPhytomer[25].Add(false); IsSmallPhytomer[25].Add(false);
            IsSmallPhytomer[26].Add(true); IsSmallPhytomer[26].Add(true); IsSmallPhytomer[26].Add(true); IsSmallPhytomer[26].Add(true); IsSmallPhytomer[26].Add(true); IsSmallPhytomer[26].Add(false); IsSmallPhytomer[26].Add(false); IsSmallPhytomer[26].Add(false);
            IsSmallPhytomer[27].Add(true); IsSmallPhytomer[27].Add(true); IsSmallPhytomer[27].Add(true); IsSmallPhytomer[27].Add(true); IsSmallPhytomer[27].Add(true); IsSmallPhytomer[27].Add(false); IsSmallPhytomer[27].Add(false); IsSmallPhytomer[27].Add(false);
            IsSmallPhytomer[28].Add(true); IsSmallPhytomer[28].Add(true); IsSmallPhytomer[28].Add(true); IsSmallPhytomer[28].Add(true); IsSmallPhytomer[28].Add(true); IsSmallPhytomer[28].Add(false); IsSmallPhytomer[28].Add(false); IsSmallPhytomer[28].Add(false); IsSmallPhytomer[28].Add(false);
            IsSmallPhytomer[29].Add(true); IsSmallPhytomer[29].Add(true); IsSmallPhytomer[29].Add(true); IsSmallPhytomer[29].Add(true); IsSmallPhytomer[29].Add(true); IsSmallPhytomer[29].Add(false); IsSmallPhytomer[29].Add(false); IsSmallPhytomer[29].Add(false); IsSmallPhytomer[29].Add(false);
            IsSmallPhytomer[30].Add(true); IsSmallPhytomer[30].Add(true); IsSmallPhytomer[30].Add(true); IsSmallPhytomer[30].Add(true); IsSmallPhytomer[30].Add(true); IsSmallPhytomer[30].Add(false); IsSmallPhytomer[30].Add(false); IsSmallPhytomer[30].Add(false); IsSmallPhytomer[30].Add(false);
            IsSmallPhytomer[31].Add(true); IsSmallPhytomer[31].Add(true); IsSmallPhytomer[31].Add(true); IsSmallPhytomer[31].Add(true); IsSmallPhytomer[31].Add(true); IsSmallPhytomer[31].Add(false); IsSmallPhytomer[31].Add(false); IsSmallPhytomer[31].Add(false); IsSmallPhytomer[31].Add(false);
            IsSmallPhytomer[32].Add(true); IsSmallPhytomer[32].Add(true); IsSmallPhytomer[32].Add(true); IsSmallPhytomer[32].Add(true); IsSmallPhytomer[32].Add(true); IsSmallPhytomer[32].Add(false); IsSmallPhytomer[32].Add(false); IsSmallPhytomer[32].Add(false); IsSmallPhytomer[32].Add(false);
            IsSmallPhytomer[33].Add(true); IsSmallPhytomer[33].Add(true); IsSmallPhytomer[33].Add(true); IsSmallPhytomer[33].Add(true); IsSmallPhytomer[33].Add(true); IsSmallPhytomer[33].Add(false); IsSmallPhytomer[33].Add(false); IsSmallPhytomer[33].Add(false); IsSmallPhytomer[33].Add(false);
            IsSmallPhytomer[34].Add(true); IsSmallPhytomer[34].Add(true); IsSmallPhytomer[34].Add(true); IsSmallPhytomer[34].Add(true); IsSmallPhytomer[34].Add(true); IsSmallPhytomer[34].Add(false); IsSmallPhytomer[34].Add(false); IsSmallPhytomer[34].Add(false); IsSmallPhytomer[34].Add(false);
            IsSmallPhytomer[35].Add(true); IsSmallPhytomer[35].Add(true); IsSmallPhytomer[35].Add(true); IsSmallPhytomer[35].Add(true); IsSmallPhytomer[35].Add(true); IsSmallPhytomer[35].Add(false); IsSmallPhytomer[35].Add(false); IsSmallPhytomer[35].Add(false); IsSmallPhytomer[35].Add(false);
            IsSmallPhytomer[36].Add(true); IsSmallPhytomer[36].Add(true); IsSmallPhytomer[36].Add(true); IsSmallPhytomer[36].Add(true); IsSmallPhytomer[36].Add(true); IsSmallPhytomer[36].Add(false); IsSmallPhytomer[36].Add(false); IsSmallPhytomer[36].Add(false); IsSmallPhytomer[36].Add(false);
            IsSmallPhytomer[37].Add(true); IsSmallPhytomer[37].Add(true); IsSmallPhytomer[37].Add(true); IsSmallPhytomer[37].Add(true); IsSmallPhytomer[37].Add(true); IsSmallPhytomer[37].Add(false); IsSmallPhytomer[37].Add(false); IsSmallPhytomer[37].Add(false); IsSmallPhytomer[37].Add(false);
            IsSmallPhytomer[38].Add(true); IsSmallPhytomer[38].Add(true); IsSmallPhytomer[38].Add(true); IsSmallPhytomer[38].Add(true); IsSmallPhytomer[38].Add(true); IsSmallPhytomer[38].Add(false); IsSmallPhytomer[38].Add(false); IsSmallPhytomer[38].Add(false); IsSmallPhytomer[38].Add(false);
            IsSmallPhytomer[39].Add(true); IsSmallPhytomer[39].Add(true); IsSmallPhytomer[39].Add(true); IsSmallPhytomer[39].Add(true); IsSmallPhytomer[39].Add(true); IsSmallPhytomer[39].Add(false); IsSmallPhytomer[39].Add(false); IsSmallPhytomer[39].Add(false); IsSmallPhytomer[39].Add(false);
            IsSmallPhytomer[40].Add(true); IsSmallPhytomer[40].Add(true); IsSmallPhytomer[40].Add(true); IsSmallPhytomer[40].Add(true); IsSmallPhytomer[40].Add(true); IsSmallPhytomer[40].Add(false); IsSmallPhytomer[40].Add(false); IsSmallPhytomer[40].Add(false); IsSmallPhytomer[40].Add(false);
            IsSmallPhytomer[41].Add(true); IsSmallPhytomer[41].Add(true); IsSmallPhytomer[41].Add(true); IsSmallPhytomer[41].Add(true); IsSmallPhytomer[41].Add(true); IsSmallPhytomer[41].Add(false); IsSmallPhytomer[41].Add(false); IsSmallPhytomer[41].Add(false); IsSmallPhytomer[41].Add(false);
            IsSmallPhytomer[42].Add(true); IsSmallPhytomer[42].Add(true); IsSmallPhytomer[42].Add(true); IsSmallPhytomer[42].Add(true); IsSmallPhytomer[42].Add(true); IsSmallPhytomer[42].Add(false); IsSmallPhytomer[42].Add(false); IsSmallPhytomer[42].Add(false); IsSmallPhytomer[42].Add(false);
            IsSmallPhytomer[43].Add(true); IsSmallPhytomer[43].Add(true); IsSmallPhytomer[43].Add(true); IsSmallPhytomer[43].Add(true); IsSmallPhytomer[43].Add(true); IsSmallPhytomer[43].Add(false); IsSmallPhytomer[43].Add(false); IsSmallPhytomer[43].Add(false); IsSmallPhytomer[43].Add(false);
            IsSmallPhytomer[44].Add(true); IsSmallPhytomer[44].Add(true); IsSmallPhytomer[44].Add(true); IsSmallPhytomer[44].Add(true); IsSmallPhytomer[44].Add(true); IsSmallPhytomer[44].Add(false); IsSmallPhytomer[44].Add(false); IsSmallPhytomer[44].Add(false); IsSmallPhytomer[44].Add(false);
            IsSmallPhytomer[45].Add(true); IsSmallPhytomer[45].Add(true); IsSmallPhytomer[45].Add(true); IsSmallPhytomer[45].Add(true); IsSmallPhytomer[45].Add(true); IsSmallPhytomer[45].Add(false); IsSmallPhytomer[45].Add(false); IsSmallPhytomer[45].Add(false); IsSmallPhytomer[45].Add(false);
            IsSmallPhytomer[46].Add(true); IsSmallPhytomer[46].Add(true); IsSmallPhytomer[46].Add(true); IsSmallPhytomer[46].Add(true); IsSmallPhytomer[46].Add(true); IsSmallPhytomer[46].Add(false); IsSmallPhytomer[46].Add(false); IsSmallPhytomer[46].Add(false); IsSmallPhytomer[46].Add(false);
            IsSmallPhytomer[47].Add(true); IsSmallPhytomer[47].Add(true); IsSmallPhytomer[47].Add(true); IsSmallPhytomer[47].Add(true); IsSmallPhytomer[47].Add(true); IsSmallPhytomer[47].Add(false); IsSmallPhytomer[47].Add(false); IsSmallPhytomer[47].Add(false); IsSmallPhytomer[47].Add(false);
            IsSmallPhytomer[48].Add(true); IsSmallPhytomer[48].Add(true); IsSmallPhytomer[48].Add(true); IsSmallPhytomer[48].Add(true); IsSmallPhytomer[48].Add(true); IsSmallPhytomer[48].Add(false); IsSmallPhytomer[48].Add(false); IsSmallPhytomer[48].Add(false); IsSmallPhytomer[48].Add(false);
            IsSmallPhytomer[49].Add(true); IsSmallPhytomer[49].Add(true); IsSmallPhytomer[49].Add(true); IsSmallPhytomer[49].Add(true); IsSmallPhytomer[49].Add(true); IsSmallPhytomer[49].Add(false); IsSmallPhytomer[49].Add(false); IsSmallPhytomer[49].Add(false); IsSmallPhytomer[49].Add(false);
            IsSmallPhytomer[50].Add(true); IsSmallPhytomer[50].Add(true); IsSmallPhytomer[50].Add(true); IsSmallPhytomer[50].Add(true); IsSmallPhytomer[50].Add(true); IsSmallPhytomer[50].Add(false); IsSmallPhytomer[50].Add(false); IsSmallPhytomer[50].Add(false); IsSmallPhytomer[50].Add(false);
            IsSmallPhytomer[51].Add(true); IsSmallPhytomer[51].Add(true); IsSmallPhytomer[51].Add(true); IsSmallPhytomer[51].Add(true); IsSmallPhytomer[51].Add(true); IsSmallPhytomer[51].Add(false); IsSmallPhytomer[51].Add(false); IsSmallPhytomer[51].Add(false); IsSmallPhytomer[51].Add(false);
            IsSmallPhytomer[52].Add(true); IsSmallPhytomer[52].Add(true); IsSmallPhytomer[52].Add(true); IsSmallPhytomer[52].Add(true); IsSmallPhytomer[52].Add(true); IsSmallPhytomer[52].Add(false); IsSmallPhytomer[52].Add(false); IsSmallPhytomer[52].Add(false); IsSmallPhytomer[52].Add(false);
            IsSmallPhytomer[53].Add(true); IsSmallPhytomer[53].Add(true); IsSmallPhytomer[53].Add(true); IsSmallPhytomer[53].Add(true); IsSmallPhytomer[53].Add(true); IsSmallPhytomer[53].Add(false); IsSmallPhytomer[53].Add(false); IsSmallPhytomer[53].Add(false); IsSmallPhytomer[53].Add(false);
            IsSmallPhytomer[54].Add(true); IsSmallPhytomer[54].Add(true); IsSmallPhytomer[54].Add(true); IsSmallPhytomer[54].Add(true); IsSmallPhytomer[54].Add(true); IsSmallPhytomer[54].Add(false); IsSmallPhytomer[54].Add(false); IsSmallPhytomer[54].Add(false); IsSmallPhytomer[54].Add(false);
            IsSmallPhytomer[55].Add(true); IsSmallPhytomer[55].Add(true); IsSmallPhytomer[55].Add(true); IsSmallPhytomer[55].Add(true); IsSmallPhytomer[55].Add(true); IsSmallPhytomer[55].Add(false); IsSmallPhytomer[55].Add(false); IsSmallPhytomer[55].Add(false); IsSmallPhytomer[55].Add(false);
            IsSmallPhytomer[56].Add(true); IsSmallPhytomer[56].Add(true); IsSmallPhytomer[56].Add(true); IsSmallPhytomer[56].Add(true); IsSmallPhytomer[56].Add(true); IsSmallPhytomer[56].Add(false); IsSmallPhytomer[56].Add(false); IsSmallPhytomer[56].Add(false); IsSmallPhytomer[56].Add(false);
            IsSmallPhytomer[57].Add(true); IsSmallPhytomer[57].Add(true); IsSmallPhytomer[57].Add(true); IsSmallPhytomer[57].Add(true); IsSmallPhytomer[57].Add(true); IsSmallPhytomer[57].Add(false); IsSmallPhytomer[57].Add(false); IsSmallPhytomer[57].Add(false); IsSmallPhytomer[57].Add(false);
            IsSmallPhytomer[58].Add(true); IsSmallPhytomer[58].Add(true); IsSmallPhytomer[58].Add(true); IsSmallPhytomer[58].Add(true); IsSmallPhytomer[58].Add(true); IsSmallPhytomer[58].Add(false); IsSmallPhytomer[58].Add(false); IsSmallPhytomer[58].Add(false); IsSmallPhytomer[58].Add(false);
            IsSmallPhytomer[59].Add(true); IsSmallPhytomer[59].Add(true); IsSmallPhytomer[59].Add(true); IsSmallPhytomer[59].Add(true); IsSmallPhytomer[59].Add(true); IsSmallPhytomer[59].Add(false); IsSmallPhytomer[59].Add(false); IsSmallPhytomer[59].Add(false); IsSmallPhytomer[59].Add(false);
            IsSmallPhytomer[60].Add(true); IsSmallPhytomer[60].Add(true); IsSmallPhytomer[60].Add(true); IsSmallPhytomer[60].Add(true); IsSmallPhytomer[60].Add(true); IsSmallPhytomer[60].Add(false); IsSmallPhytomer[60].Add(false); IsSmallPhytomer[60].Add(false); IsSmallPhytomer[60].Add(false);
            IsSmallPhytomer[61].Add(true); IsSmallPhytomer[61].Add(true); IsSmallPhytomer[61].Add(true); IsSmallPhytomer[61].Add(true); IsSmallPhytomer[61].Add(true); IsSmallPhytomer[61].Add(false); IsSmallPhytomer[61].Add(false); IsSmallPhytomer[61].Add(false); IsSmallPhytomer[61].Add(false);
            IsSmallPhytomer[62].Add(true); IsSmallPhytomer[62].Add(true); IsSmallPhytomer[62].Add(true); IsSmallPhytomer[62].Add(true); IsSmallPhytomer[62].Add(true); IsSmallPhytomer[62].Add(false); IsSmallPhytomer[62].Add(false); IsSmallPhytomer[62].Add(false); IsSmallPhytomer[62].Add(false);
            IsSmallPhytomer[63].Add(true); IsSmallPhytomer[63].Add(true); IsSmallPhytomer[63].Add(true); IsSmallPhytomer[63].Add(true); IsSmallPhytomer[63].Add(true); IsSmallPhytomer[63].Add(false); IsSmallPhytomer[63].Add(false); IsSmallPhytomer[63].Add(false); IsSmallPhytomer[63].Add(false);
            IsSmallPhytomer[64].Add(true); IsSmallPhytomer[64].Add(true); IsSmallPhytomer[64].Add(true); IsSmallPhytomer[64].Add(true); IsSmallPhytomer[64].Add(true); IsSmallPhytomer[64].Add(false); IsSmallPhytomer[64].Add(false); IsSmallPhytomer[64].Add(false); IsSmallPhytomer[64].Add(false);
            IsSmallPhytomer[65].Add(true); IsSmallPhytomer[65].Add(true); IsSmallPhytomer[65].Add(true); IsSmallPhytomer[65].Add(true); IsSmallPhytomer[65].Add(true); IsSmallPhytomer[65].Add(false); IsSmallPhytomer[65].Add(false); IsSmallPhytomer[65].Add(false); IsSmallPhytomer[65].Add(false);
            IsSmallPhytomer[66].Add(true); IsSmallPhytomer[66].Add(true); IsSmallPhytomer[66].Add(true); IsSmallPhytomer[66].Add(true); IsSmallPhytomer[66].Add(true); IsSmallPhytomer[66].Add(false); IsSmallPhytomer[66].Add(false); IsSmallPhytomer[66].Add(false); IsSmallPhytomer[66].Add(false);
            IsSmallPhytomer[67].Add(true); IsSmallPhytomer[67].Add(true); IsSmallPhytomer[67].Add(true); IsSmallPhytomer[67].Add(true); IsSmallPhytomer[67].Add(true); IsSmallPhytomer[67].Add(false); IsSmallPhytomer[67].Add(false); IsSmallPhytomer[67].Add(false); IsSmallPhytomer[67].Add(false);
            IsSmallPhytomer[68].Add(true); IsSmallPhytomer[68].Add(true); IsSmallPhytomer[68].Add(true); IsSmallPhytomer[68].Add(true); IsSmallPhytomer[68].Add(true); IsSmallPhytomer[68].Add(false); IsSmallPhytomer[68].Add(false); IsSmallPhytomer[68].Add(false); IsSmallPhytomer[68].Add(false);
            #endregion
            
            #endregion

            #region Output

            List<List<string>> State = new List<List<string>>();
            #region Valorize
            State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>()); State.Add(new List<string>());
            State[0].Add("Growing");
            State[1].Add("Growing"); State[1].Add("Growing");
            State[2].Add("Growing"); State[2].Add("Growing");
            State[3].Add("Growing"); State[3].Add("Growing");
            State[4].Add("Mature"); State[4].Add("Mature"); State[4].Add("Growing");
            State[5].Add("Mature"); State[5].Add("Mature"); State[5].Add("Growing");
            State[6].Add("Mature"); State[6].Add("Mature"); State[6].Add("Mature"); State[6].Add("Growing");
            State[7].Add("Mature"); State[7].Add("Mature"); State[7].Add("Mature"); State[7].Add("Growing");
            State[8].Add("Senescing"); State[8].Add("Senescing"); State[8].Add("Mature"); State[8].Add("Growing");
            State[9].Add("Senescing"); State[9].Add("Senescing"); State[9].Add("Senescing"); State[9].Add("Growing"); State[9].Add("Growing");
            State[10].Add("Dead"); State[10].Add("Dead"); State[10].Add("Senescing"); State[10].Add("Growing"); State[10].Add("Growing");
            State[11].Add("Dead"); State[11].Add("Dead"); State[11].Add("Dead"); State[11].Add("Growing"); State[11].Add("Growing");
            State[12].Add("Dead"); State[12].Add("Dead"); State[12].Add("Dead"); State[12].Add("Mature"); State[12].Add("Growing");
            State[13].Add("Dead"); State[13].Add("Dead"); State[13].Add("Dead"); State[13].Add("Mature"); State[13].Add("Growing");
            State[14].Add("Dead"); State[14].Add("Dead"); State[14].Add("Dead"); State[14].Add("Mature"); State[14].Add("Growing"); State[14].Add("Growing");
            State[15].Add("Dead"); State[15].Add("Dead"); State[15].Add("Dead"); State[15].Add("Mature"); State[15].Add("Mature"); State[15].Add("Growing");
            State[16].Add("Dead"); State[16].Add("Dead"); State[16].Add("Dead"); State[16].Add("Mature"); State[16].Add("Mature"); State[16].Add("Growing");
            State[17].Add("Dead"); State[17].Add("Dead"); State[17].Add("Dead"); State[17].Add("Senescing"); State[17].Add("Mature"); State[17].Add("Growing");
            State[18].Add("Dead"); State[18].Add("Dead"); State[18].Add("Dead"); State[18].Add("Senescing"); State[18].Add("Mature"); State[18].Add("Growing"); State[18].Add("Growing");
            State[19].Add("Dead"); State[19].Add("Dead"); State[19].Add("Dead"); State[19].Add("Senescing"); State[19].Add("Mature"); State[19].Add("Growing"); State[19].Add("Growing");
            State[20].Add("Dead"); State[20].Add("Dead"); State[20].Add("Dead"); State[20].Add("Senescing"); State[20].Add("Mature"); State[20].Add("Mature"); State[20].Add("Growing");
            State[21].Add("Dead"); State[21].Add("Dead"); State[21].Add("Dead"); State[21].Add("Senescing"); State[21].Add("Mature"); State[21].Add("Mature"); State[21].Add("Growing");
            State[22].Add("Dead"); State[22].Add("Dead"); State[22].Add("Dead"); State[22].Add("Senescing"); State[22].Add("Mature"); State[22].Add("Mature"); State[22].Add("Growing");
            State[23].Add("Dead"); State[23].Add("Dead"); State[23].Add("Dead"); State[23].Add("Senescing"); State[23].Add("Mature"); State[23].Add("Mature"); State[23].Add("Growing"); State[23].Add("Growing");
            State[24].Add("Dead"); State[24].Add("Dead"); State[24].Add("Dead"); State[24].Add("Senescing"); State[24].Add("Mature"); State[24].Add("Mature"); State[24].Add("Growing"); State[24].Add("Growing");
            State[25].Add("Dead"); State[25].Add("Dead"); State[25].Add("Dead"); State[25].Add("Dead"); State[25].Add("Senescing"); State[25].Add("Mature"); State[25].Add("Growing"); State[25].Add("Growing");
            State[26].Add("Dead"); State[26].Add("Dead"); State[26].Add("Dead"); State[26].Add("Dead"); State[26].Add("Senescing"); State[26].Add("Mature"); State[26].Add("Growing"); State[26].Add("Growing");
            State[27].Add("Dead"); State[27].Add("Dead"); State[27].Add("Dead"); State[27].Add("Dead"); State[27].Add("Senescing"); State[27].Add("Mature"); State[27].Add("Mature"); State[27].Add("Growing");
            State[28].Add("Dead"); State[28].Add("Dead"); State[28].Add("Dead"); State[28].Add("Dead"); State[28].Add("Senescing"); State[28].Add("Mature"); State[28].Add("Mature"); State[28].Add("Growing"); State[28].Add("Growing");
            State[29].Add("Dead"); State[29].Add("Dead"); State[29].Add("Dead"); State[29].Add("Dead"); State[29].Add("Senescing"); State[29].Add("Mature"); State[29].Add("Mature"); State[29].Add("Growing"); State[29].Add("Growing");
            State[30].Add("Dead"); State[30].Add("Dead"); State[30].Add("Dead"); State[30].Add("Dead"); State[30].Add("Senescing"); State[30].Add("Mature"); State[30].Add("Mature"); State[30].Add("Growing"); State[30].Add("Growing");
            State[31].Add("Dead"); State[31].Add("Dead"); State[31].Add("Dead"); State[31].Add("Dead"); State[31].Add("Senescing"); State[31].Add("Mature"); State[31].Add("Mature"); State[31].Add("Growing"); State[31].Add("Growing");
            State[32].Add("Dead"); State[32].Add("Dead"); State[32].Add("Dead"); State[32].Add("Dead"); State[32].Add("Senescing"); State[32].Add("Mature"); State[32].Add("Mature"); State[32].Add("Growing"); State[32].Add("Growing");
            State[33].Add("Dead"); State[33].Add("Dead"); State[33].Add("Dead"); State[33].Add("Dead"); State[33].Add("Senescing"); State[33].Add("Mature"); State[33].Add("Mature"); State[33].Add("Mature"); State[33].Add("Growing");
            State[34].Add("Dead"); State[34].Add("Dead"); State[34].Add("Dead"); State[34].Add("Dead"); State[34].Add("Senescing"); State[34].Add("Mature"); State[34].Add("Mature"); State[34].Add("Mature"); State[34].Add("Growing");
            State[35].Add("Dead"); State[35].Add("Dead"); State[35].Add("Dead"); State[35].Add("Dead"); State[35].Add("Dead"); State[35].Add("Mature"); State[35].Add("Mature"); State[35].Add("Mature"); State[35].Add("Growing");
            State[36].Add("Dead"); State[36].Add("Dead"); State[36].Add("Dead"); State[36].Add("Dead"); State[36].Add("Dead"); State[36].Add("Mature"); State[36].Add("Mature"); State[36].Add("Mature"); State[36].Add("Growing");
            State[37].Add("Dead"); State[37].Add("Dead"); State[37].Add("Dead"); State[37].Add("Dead"); State[37].Add("Dead"); State[37].Add("Mature"); State[37].Add("Mature"); State[37].Add("Mature"); State[37].Add("Growing");
            State[38].Add("Dead"); State[38].Add("Dead"); State[38].Add("Dead"); State[38].Add("Dead"); State[38].Add("Dead"); State[38].Add("Mature"); State[38].Add("Mature"); State[38].Add("Mature"); State[38].Add("Growing");
            State[39].Add("Dead"); State[39].Add("Dead"); State[39].Add("Dead"); State[39].Add("Dead"); State[39].Add("Dead"); State[39].Add("Mature"); State[39].Add("Mature"); State[39].Add("Mature"); State[39].Add("Growing");
            State[40].Add("Dead"); State[40].Add("Dead"); State[40].Add("Dead"); State[40].Add("Dead"); State[40].Add("Dead"); State[40].Add("Mature"); State[40].Add("Mature"); State[40].Add("Mature"); State[40].Add("Growing");
            State[41].Add("Dead"); State[41].Add("Dead"); State[41].Add("Dead"); State[41].Add("Dead"); State[41].Add("Dead"); State[41].Add("Mature"); State[41].Add("Mature"); State[41].Add("Mature"); State[41].Add("Growing");
            State[42].Add("Dead"); State[42].Add("Dead"); State[42].Add("Dead"); State[42].Add("Dead"); State[42].Add("Dead"); State[42].Add("Mature"); State[42].Add("Mature"); State[42].Add("Mature"); State[42].Add("Mature");
            State[43].Add("Dead"); State[43].Add("Dead"); State[43].Add("Dead"); State[43].Add("Dead"); State[43].Add("Dead"); State[43].Add("Mature"); State[43].Add("Mature"); State[43].Add("Mature"); State[43].Add("Mature");
            State[44].Add("Dead"); State[44].Add("Dead"); State[44].Add("Dead"); State[44].Add("Dead"); State[44].Add("Dead"); State[44].Add("Mature"); State[44].Add("Mature"); State[44].Add("Mature"); State[44].Add("Mature");
            State[45].Add("Dead"); State[45].Add("Dead"); State[45].Add("Dead"); State[45].Add("Dead"); State[45].Add("Dead"); State[45].Add("Mature"); State[45].Add("Mature"); State[45].Add("Mature"); State[45].Add("Mature");
            State[46].Add("Dead"); State[46].Add("Dead"); State[46].Add("Dead"); State[46].Add("Dead"); State[46].Add("Dead"); State[46].Add("Mature"); State[46].Add("Mature"); State[46].Add("Mature"); State[46].Add("Mature");
            State[47].Add("Dead"); State[47].Add("Dead"); State[47].Add("Dead"); State[47].Add("Dead"); State[47].Add("Dead"); State[47].Add("Mature"); State[47].Add("Mature"); State[47].Add("Mature"); State[47].Add("Mature");
            State[48].Add("Dead"); State[48].Add("Dead"); State[48].Add("Dead"); State[48].Add("Dead"); State[48].Add("Dead"); State[48].Add("Mature"); State[48].Add("Mature"); State[48].Add("Mature"); State[48].Add("Mature");
            State[49].Add("Dead"); State[49].Add("Dead"); State[49].Add("Dead"); State[49].Add("Dead"); State[49].Add("Dead"); State[49].Add("Senescing"); State[49].Add("Mature"); State[49].Add("Mature"); State[49].Add("Mature");
            State[50].Add("Dead"); State[50].Add("Dead"); State[50].Add("Dead"); State[50].Add("Dead"); State[50].Add("Dead"); State[50].Add("Senescing"); State[50].Add("Mature"); State[50].Add("Mature"); State[50].Add("Mature");
            State[51].Add("Dead"); State[51].Add("Dead"); State[51].Add("Dead"); State[51].Add("Dead"); State[51].Add("Dead"); State[51].Add("Senescing"); State[51].Add("Mature"); State[51].Add("Mature"); State[51].Add("Mature");
            State[52].Add("Dead"); State[52].Add("Dead"); State[52].Add("Dead"); State[52].Add("Dead"); State[52].Add("Dead"); State[52].Add("Senescing"); State[52].Add("Mature"); State[52].Add("Mature"); State[52].Add("Mature");
            State[53].Add("Dead"); State[53].Add("Dead"); State[53].Add("Dead"); State[53].Add("Dead"); State[53].Add("Dead"); State[53].Add("Senescing"); State[53].Add("Senescing"); State[53].Add("Mature"); State[53].Add("Mature");
            State[54].Add("Dead"); State[54].Add("Dead"); State[54].Add("Dead"); State[54].Add("Dead"); State[54].Add("Dead"); State[54].Add("Senescing"); State[54].Add("Senescing"); State[54].Add("Mature"); State[54].Add("Mature");
            State[55].Add("Dead"); State[55].Add("Dead"); State[55].Add("Dead"); State[55].Add("Dead"); State[55].Add("Dead"); State[55].Add("Senescing"); State[55].Add("Senescing"); State[55].Add("Mature"); State[55].Add("Mature");
            State[56].Add("Dead"); State[56].Add("Dead"); State[56].Add("Dead"); State[56].Add("Dead"); State[56].Add("Dead"); State[56].Add("Senescing"); State[56].Add("Senescing"); State[56].Add("Mature"); State[56].Add("Mature");
            State[57].Add("Dead"); State[57].Add("Dead"); State[57].Add("Dead"); State[57].Add("Dead"); State[57].Add("Dead"); State[57].Add("Senescing"); State[57].Add("Senescing"); State[57].Add("Mature"); State[57].Add("Mature");
            State[58].Add("Dead"); State[58].Add("Dead"); State[58].Add("Dead"); State[58].Add("Dead"); State[58].Add("Dead"); State[58].Add("Senescing"); State[58].Add("Senescing"); State[58].Add("Mature"); State[58].Add("Mature");
            State[59].Add("Dead"); State[59].Add("Dead"); State[59].Add("Dead"); State[59].Add("Dead"); State[59].Add("Dead"); State[59].Add("Dead"); State[59].Add("Senescing"); State[59].Add("Senescing"); State[59].Add("Mature");
            State[60].Add("Dead"); State[60].Add("Dead"); State[60].Add("Dead"); State[60].Add("Dead"); State[60].Add("Dead"); State[60].Add("Dead"); State[60].Add("Senescing"); State[60].Add("Senescing"); State[60].Add("Mature");
            State[61].Add("Dead"); State[61].Add("Dead"); State[61].Add("Dead"); State[61].Add("Dead"); State[61].Add("Dead"); State[61].Add("Dead"); State[61].Add("Senescing"); State[61].Add("Senescing"); State[61].Add("Mature");
            State[62].Add("Dead"); State[62].Add("Dead"); State[62].Add("Dead"); State[62].Add("Dead"); State[62].Add("Dead"); State[62].Add("Dead"); State[62].Add("Senescing"); State[62].Add("Senescing"); State[62].Add("Mature");
            State[63].Add("Dead"); State[63].Add("Dead"); State[63].Add("Dead"); State[63].Add("Dead"); State[63].Add("Dead"); State[63].Add("Dead"); State[63].Add("Dead"); State[63].Add("Senescing"); State[63].Add("Mature");
            State[64].Add("Dead"); State[64].Add("Dead"); State[64].Add("Dead"); State[64].Add("Dead"); State[64].Add("Dead"); State[64].Add("Dead"); State[64].Add("Dead"); State[64].Add("Senescing"); State[64].Add("Mature");
            State[65].Add("Dead"); State[65].Add("Dead"); State[65].Add("Dead"); State[65].Add("Dead"); State[65].Add("Dead"); State[65].Add("Dead"); State[65].Add("Dead"); State[65].Add("Senescing"); State[65].Add("Senescing");
            State[66].Add("Dead"); State[66].Add("Dead"); State[66].Add("Dead"); State[66].Add("Dead"); State[66].Add("Dead"); State[66].Add("Dead"); State[66].Add("Dead"); State[66].Add("Dead"); State[66].Add("Senescing");
            State[67].Add("Dead"); State[67].Add("Dead"); State[67].Add("Dead"); State[67].Add("Dead"); State[67].Add("Dead"); State[67].Add("Dead"); State[67].Add("Dead"); State[67].Add("Dead"); State[67].Add("Senescing");
            State[68].Add("Dead"); State[68].Add("Dead"); State[68].Add("Dead"); State[68].Add("Dead"); State[68].Add("Dead"); State[68].Add("Dead"); State[68].Add("Dead"); State[68].Add("Dead"); State[68].Add("Senescing");
            #endregion

            double[] DALSF = { 0,0.251090023888001,0.155171407592656,0.139660465193226,0.0833616510158921,0.0969621242314729,
                               0.0534101654766467,0.05239085514293,0.0338073051830256,0.140071231655751,0.0713674469113416,
                               0,0,0.0324763073161471,0.170758393341928,0.103161819517081,
                               0.13428442758958,0.112079042579668,0.493818329511763,0.224294719316036,0.117846178378361,
                               0.191361453212869,0.246525786460624,0.366726278220254,0.357450932080633,0.335813771437121,
                               0.493297818270825,0.305182269745926,0.375063218235232,0.529318234977215,0.50596501039283,
                               0.479008553667807,0.42804780970842,0.222687872421776,0.262108065706628,0.214845848206287,
                               0.249054885787506,0.24804724303921,0.208556755423013,0.186791725013778,0.179507670855718,
                               0.206271779745106,0,0,0,0,
                               0,0,0,0,0,
                               0,0,0,0,0,
                               0,0,0,0,0,
                               0,0,0,0,0,
                               0,0,0};

            double[] POTDA = {0.131402143428786,0.251090023888001,0.164599488623129,0.139660465193226,0.100327058464377,0.1226476872069,
                              0.110934145572122,0.113082364965834,0.115277122730564,0.236552996364666,0.126361891792991,
                              0.178669417064816,0.112712769330171,0.130046896265629,0.336178158117984,0.205239346879979,
                              0.199625471771208,0.161910737414515,0.493818329511763,0.424346950265009,0.224576413030869,
                              0.191484563256344,0.246525786460624,0.523320146274429,0.507451392158593,0.409201230202567,
                              0.493297818270825,0.305182269745926,0.454551118662877,0.529318234977215,0.555031441037277,
                              0.587403162164874,0.524479528732763,0.257239163640244,0.289783299673555,0.256482148009129,
                              0.268707143137181,0.250466819321745,0.240590578185718,0.190000159223032,0.179507670855718,
                              0.206271779745106,0,0,0,0,
                              0,0,0,0,0,
                              0,0,0,0,0,
                              0,0,0,0,0,
                              0,0,0,0,0,
                              0,0,0 };


            List<List<double>> WLPDA = new List<List<double>>();
            #region Valorize
            WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>()); WLPDA.Add(new List<double>());
            WLPDA[0].Add(0.131402143428786);
            WLPDA[1].Add(0.125545011944001); WLPDA[1].Add(0.125545011944001);
            WLPDA[2].Add(0.0822997443115647); WLPDA[2].Add(0.0822997443115647);
            WLPDA[3].Add(0.052704); WLPDA[3].Add(0.0869564651932265);
            WLPDA[4].Add(0); WLPDA[4].Add(0); WLPDA[4].Add(0.100327058464377);
            WLPDA[5].Add(0); WLPDA[5].Add(0); WLPDA[5].Add(0.1226476872069);
            WLPDA[6].Add(0); WLPDA[6].Add(0); WLPDA[6].Add(0); WLPDA[6].Add(0.110934145572122);
            WLPDA[7].Add(0); WLPDA[7].Add(0); WLPDA[7].Add(0); WLPDA[7].Add(0.113082364965834);
            WLPDA[8].Add(-0.0225674249011604); WLPDA[8].Add(-0.0241593594435601); WLPDA[8].Add(0); WLPDA[8].Add(0.115277122730564);
            WLPDA[9].Add(-0.00897677817591268); WLPDA[9].Add(-0.00961001140124891); WLPDA[9].Add(-0.0319122517764958); WLPDA[9].Add(0.115862692096979); WLPDA[9].Add(0.120690304267687);
            WLPDA[10].Add(0); WLPDA[10].Add(0); WLPDA[10].Add(-0.0257220079373397); WLPDA[10].Add(0.0618915388373835); WLPDA[10].Add(0.0644703529556078);
            WLPDA[11].Add(0); WLPDA[11].Add(0); WLPDA[11].Add(0); WLPDA[11].Add(0.0875115512154199); WLPDA[11].Add(0.0911578658493957);
            WLPDA[12].Add(0); WLPDA[12].Add(0); WLPDA[12].Add(0); WLPDA[12].Add(0); WLPDA[12].Add(0.112712769330171);
            WLPDA[13].Add(0); WLPDA[13].Add(0); WLPDA[13].Add(0); WLPDA[13].Add(0); WLPDA[13].Add(0.130046896265629);
            WLPDA[14].Add(0); WLPDA[14].Add(0); WLPDA[14].Add(0); WLPDA[14].Add(0); WLPDA[14].Add(0.128491462366938); WLPDA[14].Add(0.207686695751046);
            WLPDA[15].Add(0); WLPDA[15].Add(0); WLPDA[15].Add(0); WLPDA[15].Add(0); WLPDA[15].Add(0); WLPDA[15].Add(0.205239346879979);
            WLPDA[16].Add(0); WLPDA[16].Add(0); WLPDA[16].Add(0); WLPDA[16].Add(0); WLPDA[16].Add(0); WLPDA[16].Add(0.199625471771208);
            WLPDA[17].Add(0); WLPDA[17].Add(0); WLPDA[17].Add(0); WLPDA[17].Add(-0.028602848562962); WLPDA[17].Add(0); WLPDA[17].Add(0.161910737414515);
            WLPDA[18].Add(0); WLPDA[18].Add(0); WLPDA[18].Add(0); WLPDA[18].Add(-0.0200442608568822); WLPDA[18].Add(0); WLPDA[18].Add(0.205647606474484); WLPDA[18].Add(0.288170723037279);
            WLPDA[19].Add(0); WLPDA[19].Add(0); WLPDA[19].Add(0); WLPDA[19].Add(-0.0511339726423371); WLPDA[19].Add(0); WLPDA[19].Add(0.17671667781758); WLPDA[19].Add(0.247630272447428);
            WLPDA[20].Add(0); WLPDA[20].Add(0); WLPDA[20].Add(0); WLPDA[20].Add(-0.0358195344727276); WLPDA[20].Add(0); WLPDA[20].Add(0); WLPDA[20].Add(0.224576413030869);
            WLPDA[21].Add(0); WLPDA[21].Add(0); WLPDA[21].Add(0); WLPDA[21].Add(-0.0118605606478482); WLPDA[21].Add(0); WLPDA[21].Add(0); WLPDA[21].Add(0.191484563256344);
            WLPDA[22].Add(0); WLPDA[22].Add(0); WLPDA[22].Add(0); WLPDA[22].Add(-0.0160572092307796); WLPDA[22].Add(0); WLPDA[22].Add(0); WLPDA[22].Add(0.246525786460624);
            WLPDA[23].Add(0); WLPDA[23].Add(0); WLPDA[23].Add(0); WLPDA[23].Add(-0.0299053879371722); WLPDA[23].Add(0); WLPDA[23].Add(0); WLPDA[23].Add(0.228887017884557); WLPDA[23].Add(0.294433128389871);
            WLPDA[24].Add(0); WLPDA[24].Add(0); WLPDA[24].Add(0); WLPDA[24].Add(-0.0244392392492377); WLPDA[24].Add(0); WLPDA[24].Add(0); WLPDA[24].Add(0.221946425528282); WLPDA[24].Add(0.28550496663031);
            WLPDA[25].Add(0); WLPDA[25].Add(0); WLPDA[25].Add(0); WLPDA[25].Add(0); WLPDA[25].Add(-0.0156250057449702); WLPDA[25].Add(0); WLPDA[25].Add(0.17897428555453); WLPDA[25].Add(0.230226944648038);
            WLPDA[26].Add(0); WLPDA[26].Add(0); WLPDA[26].Add(0); WLPDA[26].Add(0); WLPDA[26].Add(-0.0110205610949004); WLPDA[26].Add(0); WLPDA[26].Add(0.215756009694605); WLPDA[26].Add(0.277541808576221);
            WLPDA[27].Add(0); WLPDA[27].Add(0); WLPDA[27].Add(0); WLPDA[27].Add(0); WLPDA[27].Add(-0.0127074668842637); WLPDA[27].Add(0); WLPDA[27].Add(0); WLPDA[27].Add(0.305182269745926);
            WLPDA[28].Add(0); WLPDA[28].Add(0); WLPDA[28].Add(0); WLPDA[28].Add(0); WLPDA[28].Add(-0.0162318400085459); WLPDA[28].Add(0); WLPDA[28].Add(0); WLPDA[28].Add(0.24596922005567); WLPDA[28].Add(0.208581898607208);
            WLPDA[29].Add(0); WLPDA[29].Add(0); WLPDA[29].Add(0); WLPDA[29].Add(0); WLPDA[29].Add(-0.0117183311664046); WLPDA[29].Add(0); WLPDA[29].Add(0); WLPDA[29].Add(0.286427616329662); WLPDA[29].Add(0.242890618647553);
            WLPDA[30].Add(0); WLPDA[30].Add(0); WLPDA[30].Add(0); WLPDA[30].Add(0); WLPDA[30].Add(-0.0164863770079698); WLPDA[30].Add(0); WLPDA[30].Add(0); WLPDA[30].Add(0.300341688872985); WLPDA[30].Add(0.254689752164292);
            WLPDA[31].Add(0); WLPDA[31].Add(0); WLPDA[31].Add(0); WLPDA[31].Add(0); WLPDA[31].Add(-0.0212414987080964); WLPDA[31].Add(0); WLPDA[31].Add(0); WLPDA[31].Add(0.317858853985321); WLPDA[31].Add(0.269544308179553);
            WLPDA[32].Add(0); WLPDA[32].Add(0); WLPDA[32].Add(0); WLPDA[32].Add(0); WLPDA[32].Add(-0.0200124363925111); WLPDA[32].Add(0); WLPDA[32].Add(0); WLPDA[32].Add(0.283809268794785); WLPDA[32].Add(0.240670259937978);
            WLPDA[33].Add(0); WLPDA[33].Add(0); WLPDA[33].Add(0); WLPDA[33].Add(0); WLPDA[33].Add(-0.0189121644780244); WLPDA[33].Add(0); WLPDA[33].Add(0); WLPDA[33].Add(0); WLPDA[33].Add(0.257239163640244);
            WLPDA[34].Add(0); WLPDA[34].Add(0); WLPDA[34].Add(0); WLPDA[34].Add(0); WLPDA[34].Add(-0.00257435376509544); WLPDA[34].Add(0); WLPDA[34].Add(0); WLPDA[34].Add(0); WLPDA[34].Add(0.289783299673555);
            WLPDA[35].Add(0); WLPDA[35].Add(0); WLPDA[35].Add(0); WLPDA[35].Add(0); WLPDA[35].Add(0); WLPDA[35].Add(0); WLPDA[35].Add(0); WLPDA[35].Add(0); WLPDA[35].Add(0.256482148009129);
            WLPDA[36].Add(0); WLPDA[36].Add(0); WLPDA[36].Add(0); WLPDA[36].Add(0); WLPDA[36].Add(0); WLPDA[36].Add(0); WLPDA[36].Add(0); WLPDA[36].Add(0); WLPDA[36].Add(0.268707143137181);
            WLPDA[37].Add(0); WLPDA[37].Add(0); WLPDA[37].Add(0); WLPDA[37].Add(0); WLPDA[37].Add(0); WLPDA[37].Add(0); WLPDA[37].Add(0); WLPDA[37].Add(0); WLPDA[37].Add(0.250466819321745);
            WLPDA[38].Add(0); WLPDA[38].Add(0); WLPDA[38].Add(0); WLPDA[38].Add(0); WLPDA[38].Add(0); WLPDA[38].Add(0); WLPDA[38].Add(0); WLPDA[38].Add(0); WLPDA[38].Add(0.240590578185718);
            WLPDA[39].Add(0); WLPDA[39].Add(0); WLPDA[39].Add(0); WLPDA[39].Add(0); WLPDA[39].Add(0); WLPDA[39].Add(0); WLPDA[39].Add(0); WLPDA[39].Add(0); WLPDA[39].Add(0.190000159223032);
            WLPDA[40].Add(0); WLPDA[40].Add(0); WLPDA[40].Add(0); WLPDA[40].Add(0); WLPDA[40].Add(0); WLPDA[40].Add(0); WLPDA[40].Add(0); WLPDA[40].Add(0); WLPDA[40].Add(0.179507670855718);
            WLPDA[41].Add(0); WLPDA[41].Add(0); WLPDA[41].Add(0); WLPDA[41].Add(0); WLPDA[41].Add(0); WLPDA[41].Add(0); WLPDA[41].Add(0); WLPDA[41].Add(0); WLPDA[41].Add(0.206271779745106);
            WLPDA[42].Add(0); WLPDA[42].Add(0); WLPDA[42].Add(0); WLPDA[42].Add(0); WLPDA[42].Add(0); WLPDA[42].Add(0); WLPDA[42].Add(0); WLPDA[42].Add(0); WLPDA[42].Add(0);
            WLPDA[43].Add(0); WLPDA[43].Add(0); WLPDA[43].Add(0); WLPDA[43].Add(0); WLPDA[43].Add(0); WLPDA[43].Add(0); WLPDA[43].Add(0); WLPDA[43].Add(0); WLPDA[43].Add(0);
            WLPDA[44].Add(0); WLPDA[44].Add(0); WLPDA[44].Add(0); WLPDA[44].Add(0); WLPDA[44].Add(0); WLPDA[44].Add(0); WLPDA[44].Add(0); WLPDA[44].Add(0); WLPDA[44].Add(0);
            WLPDA[45].Add(0); WLPDA[45].Add(0); WLPDA[45].Add(0); WLPDA[45].Add(0); WLPDA[45].Add(0); WLPDA[45].Add(0); WLPDA[45].Add(0); WLPDA[45].Add(0); WLPDA[45].Add(0);
            WLPDA[46].Add(0); WLPDA[46].Add(0); WLPDA[46].Add(0); WLPDA[46].Add(0); WLPDA[46].Add(0); WLPDA[46].Add(0); WLPDA[46].Add(0); WLPDA[46].Add(0); WLPDA[46].Add(0);
            WLPDA[47].Add(0); WLPDA[47].Add(0); WLPDA[47].Add(0); WLPDA[47].Add(0); WLPDA[47].Add(0); WLPDA[47].Add(0); WLPDA[47].Add(0); WLPDA[47].Add(0); WLPDA[47].Add(0);
            WLPDA[48].Add(0); WLPDA[48].Add(0); WLPDA[48].Add(0); WLPDA[48].Add(0); WLPDA[48].Add(0); WLPDA[48].Add(0); WLPDA[48].Add(0); WLPDA[48].Add(0); WLPDA[48].Add(0);
            WLPDA[49].Add(0); WLPDA[49].Add(0); WLPDA[49].Add(0); WLPDA[49].Add(0); WLPDA[49].Add(0); WLPDA[49].Add(-0.0562812256822211); WLPDA[49].Add(0); WLPDA[49].Add(0); WLPDA[49].Add(0);
            WLPDA[50].Add(0); WLPDA[50].Add(0); WLPDA[50].Add(0); WLPDA[50].Add(0); WLPDA[50].Add(0); WLPDA[50].Add(-0.0456123141763044); WLPDA[50].Add(0); WLPDA[50].Add(0); WLPDA[50].Add(0);
            WLPDA[51].Add(0); WLPDA[51].Add(0); WLPDA[51].Add(0); WLPDA[51].Add(0); WLPDA[51].Add(0); WLPDA[51].Add(-0.0482535785457818); WLPDA[51].Add(0); WLPDA[51].Add(0); WLPDA[51].Add(0);
            WLPDA[52].Add(0); WLPDA[52].Add(0); WLPDA[52].Add(0); WLPDA[52].Add(0); WLPDA[52].Add(0); WLPDA[52].Add(-0.0429411009795659); WLPDA[52].Add(0); WLPDA[52].Add(0); WLPDA[52].Add(0);
            WLPDA[53].Add(0); WLPDA[53].Add(0); WLPDA[53].Add(0); WLPDA[53].Add(0); WLPDA[53].Add(0); WLPDA[53].Add(-0.0611392793930207); WLPDA[53].Add(-0.134278156278693); WLPDA[53].Add(0); WLPDA[53].Add(0);
            WLPDA[54].Add(0); WLPDA[54].Add(0); WLPDA[54].Add(0); WLPDA[54].Add(0); WLPDA[54].Add(0); WLPDA[54].Add(-0.0551533496164408); WLPDA[54].Add(-0.121131458738377); WLPDA[54].Add(0); WLPDA[54].Add(0);
            WLPDA[55].Add(0); WLPDA[55].Add(0); WLPDA[55].Add(0); WLPDA[55].Add(0); WLPDA[55].Add(0); WLPDA[55].Add(-0.0576358009793504); WLPDA[55].Add(-0.126583583712246); WLPDA[55].Add(0); WLPDA[55].Add(0);
            WLPDA[56].Add(0); WLPDA[56].Add(0); WLPDA[56].Add(0); WLPDA[56].Add(0); WLPDA[56].Add(0); WLPDA[56].Add(-0.0463246683412121); WLPDA[56].Add(-0.101741321075989); WLPDA[56].Add(0); WLPDA[56].Add(0);
            WLPDA[57].Add(0); WLPDA[57].Add(0); WLPDA[57].Add(0); WLPDA[57].Add(0); WLPDA[57].Add(0); WLPDA[57].Add(-0.0343875502161784); WLPDA[57].Add(-0.0755242274330191); WLPDA[57].Add(0); WLPDA[57].Add(0);
            WLPDA[58].Add(0); WLPDA[58].Add(0); WLPDA[58].Add(0); WLPDA[58].Add(0); WLPDA[58].Add(0); WLPDA[58].Add(-0.0250907268992681); WLPDA[58].Add(-0.0664450393212615); WLPDA[58].Add(0); WLPDA[58].Add(0);
            WLPDA[59].Add(0); WLPDA[59].Add(0); WLPDA[59].Add(0); WLPDA[59].Add(0); WLPDA[59].Add(0); WLPDA[59].Add(0); WLPDA[59].Add(-0.103480261302339); WLPDA[59].Add(-0.154486092535453); WLPDA[59].Add(0);
            WLPDA[60].Add(0); WLPDA[60].Add(0); WLPDA[60].Add(0); WLPDA[60].Add(0); WLPDA[60].Add(0); WLPDA[60].Add(0); WLPDA[60].Add(-0.13813183890474); WLPDA[60].Add(-0.20621757017778); WLPDA[60].Add(0);
            WLPDA[61].Add(0); WLPDA[61].Add(0); WLPDA[61].Add(0); WLPDA[61].Add(0); WLPDA[61].Add(0); WLPDA[61].Add(0); WLPDA[61].Add(-0.154639135581874); WLPDA[61].Add(-0.230861378860511); WLPDA[61].Add(0);
            WLPDA[62].Add(0); WLPDA[62].Add(0); WLPDA[62].Add(0); WLPDA[62].Add(0); WLPDA[62].Add(0); WLPDA[62].Add(0); WLPDA[62].Add(-0.0533888175049363); WLPDA[62].Add(-0.268949611778751); WLPDA[62].Add(0);
            WLPDA[63].Add(0); WLPDA[63].Add(0); WLPDA[63].Add(0); WLPDA[63].Add(0); WLPDA[63].Add(0); WLPDA[63].Add(0); WLPDA[63].Add(0); WLPDA[63].Add(-0.302831097917947); WLPDA[63].Add(0);
            WLPDA[64].Add(0); WLPDA[64].Add(0); WLPDA[64].Add(0); WLPDA[64].Add(0); WLPDA[64].Add(0); WLPDA[64].Add(0); WLPDA[64].Add(0); WLPDA[64].Add(-0.335890208975805); WLPDA[64].Add(0);
            WLPDA[65].Add(0); WLPDA[65].Add(0); WLPDA[65].Add(0); WLPDA[65].Add(0); WLPDA[65].Add(0); WLPDA[65].Add(0); WLPDA[65].Add(0); WLPDA[65].Add(-0.204171072683324); WLPDA[65].Add(-0.451151274095547);
            WLPDA[66].Add(0); WLPDA[66].Add(0); WLPDA[66].Add(0); WLPDA[66].Add(0); WLPDA[66].Add(0); WLPDA[66].Add(0); WLPDA[66].Add(0); WLPDA[66].Add(0); WLPDA[66].Add(-0.564251694375992);
            WLPDA[67].Add(0); WLPDA[67].Add(0); WLPDA[67].Add(0); WLPDA[67].Add(0); WLPDA[67].Add(0); WLPDA[67].Add(0); WLPDA[67].Add(0); WLPDA[67].Add(0); WLPDA[67].Add(-0.615067320755823);
            WLPDA[68].Add(0); WLPDA[68].Add(0); WLPDA[68].Add(0); WLPDA[68].Add(0); WLPDA[68].Add(0); WLPDA[68].Add(0); WLPDA[68].Add(0); WLPDA[68].Add(0); WLPDA[68].Add(-0.329043835030131);
            #endregion

            #endregion

            #region Call of the component

            int previousIndex = -1;

            for (int iday = 0; iday < LeafNumber.Length; iday++)
            {
                //Create Layers
                if (iday==0)
                {
                    wheatLeafstate_.State.Add(0);
                    wheatLeafstate_.isPrematurelyDying.Add(0);
                    wheatLeafstate_.isSmallPhytomer.Add(0);
                    wheatLeafstate_.GAI.Add(0.0);
                    wheatLeafstate_.PreviousState.Add(0);
                    wheatLeafstate_.TTsen.Add(0.0);
                    wheatLeafstate_.TTmat.Add(0.0);
                    wheatLeafstate_.TTem.Add(0.0);
                    wheatLeafstate_.TTGroLamina.Add(0.0);
                    wheatLeafstate_.MaxAI.Add(0.0);
                    wheatLeafstate_.Phyllochron.Add(0.0);
                    wheatLeafstate_.laminaSpecificN.Add(0.0);
                    wheatLeafstate_.LaminaAI.Add(0.0);
                    wheatLeafstate_.SheathAI.Add(0.0);


                    wheatLeafstate1_.State.Add(0);
                    wheatLeafstate1_.isPrematurelyDying.Add(0);
                }
                else if (GAI[iday].Count != GAI[iday - 1].Count)
                {
                    wheatLeafstate_.State.Add(0);
                    wheatLeafstate_.isPrematurelyDying.Add(0);
                    wheatLeafstate_.isSmallPhytomer.Add(0);
                    wheatLeafstate_.GAI.Add(0.0);
                    wheatLeafstate_.PreviousState.Add(0);
                    wheatLeafstate_.TTsen.Add(0.0);
                    wheatLeafstate_.TTmat.Add(0.0);
                    wheatLeafstate_.TTem.Add(0.0);
                    wheatLeafstate_.TTGroLamina.Add(0.0);
                    wheatLeafstate_.MaxAI.Add(0.0);
                    wheatLeafstate_.Phyllochron.Add(0.0);
                    wheatLeafstate_.laminaSpecificN.Add(0.0);
                    wheatLeafstate_.LaminaAI.Add(0.0);
                    wheatLeafstate_.SheathAI.Add(0.0);


                    wheatLeafstate1_.State.Add(0);
                    wheatLeafstate1_.isPrematurelyDying.Add(0);
                }



                //Valorize inputs
                wheatLaistate_.newLeafHasAppeared = HasNewLeafAppeared[iday] ? 1 : 0;
                wheatLaistate_.roundedFinalLeafNumber = roundedFinalNumber[iday];
                wheatLaistate_.finalLeafNumber = FinalLeafNumber[iday];
                wheatLaistate_.leafNumber = LeafNumber[iday];
                wheatLaistate_.FPAW = FPAW[iday];
                wheatLaistate_.isPotentialLAI = isPotentialLAI ? 1 : 0;
                wheatLaistate_.cumulTTShoot = cumulTTShoot[iday];
                wheatLaistate_.deltaTTShoot = deltaTTShoot[iday];
                wheatLaistate_.deltaTTSenescence = deltaTTSenescence[iday];
                wheatLaistate_.VPDairCanopy = VPDairCanopy[iday];
                wheatLaistate_.tilleringProfile = tilleringProfile[iday];
                wheatLaistate_.leafTillerNumberArray = leafTillerNumberArray[iday];
                wheatLaistate_.phytonum = newLeafLastPhytoNum[iday];
                wheatLaistate_.index = newLeafindex[iday];
                wheatLaistate_.previousIndex = previousIndex;
                previousIndex = newLeafindex[iday];

                //Valorize the leaf layer states of the component from the leaf Layer class

                for (int ilayer = 0; ilayer < LayerState[iday].Count; ilayer++)
                {

                    switch (LayerState[iday][ilayer])
                    {
                        case "Growing":
                            wheatLeafstate_.State[ilayer] = 0;
                            break;
                        case "Mature":
                            wheatLeafstate_.State[ilayer] = 1;
                            break;
                        case "Senescing":
                            wheatLeafstate_.State[ilayer] = 2;
                            break;
                        case "Dead":
                            wheatLeafstate_.State[ilayer] = 3;
                            break;
                    }
                    wheatLeafstate_.GAI[ilayer] = GAI[iday][ilayer];
                    wheatLeafstate_.MaxAI[ilayer] = MaxAI[iday][ilayer];
                    wheatLeafstate_.Phyllochron[ilayer] = LayerPhyllochron[iday][ilayer];
                    wheatLeafstate_.TTGroLamina[ilayer] = TTgroLamina[iday][ilayer];
                    wheatLeafstate_.laminaSpecificN[ilayer] = LaminaSpecificN[iday][ilayer];
                    wheatLeafstate_.LaminaAI[ilayer] = LaminaAreaIndex[iday][ilayer];
                    wheatLeafstate_.SheathAI[ilayer] = SheathAreaIndex[iday][ilayer];
                    wheatLeafstate_.isPrematurelyDying[ilayer] = IsPrematurelyDying[iday][ilayer] ? 1 : 0;
                    wheatLeafstate_.TTem[ilayer] = TTem[iday][ilayer];

                    if (IsSmallPhytomer[iday][ilayer] == true) wheatLeafstate_.isSmallPhytomer[ilayer] = 1;
                    else wheatLeafstate_.isSmallPhytomer[ilayer] = 0;

                }

                //Call the estimate function of the composite class
                wheatLAI_.Estimate(wheatLaistate_, wheatLeafstate_, wheatLeafstate1_, null);

                #region Tests

                for (int ilayer = 0; ilayer < GAI[iday].Count; ilayer++) Assert.AreEqual(State[iday][ilayer], GetStateListWheat()[ilayer]);
                for (int ilayer = 0; ilayer < GAI[iday].Count; ilayer++) Assert.AreEqual(WLPDA[iday][ilayer], wheatLaistate_.WaterLimitedPotDeltaAIList[ilayer], 0.00001);

                Assert.AreEqual(DALSF[iday], wheatLaistate_.incDeltaAreaLimitSF, 0.00001);
                Assert.AreEqual(POTDA[iday], wheatLaistate_.potentialIncDeltaArea, 0.00001);

                #endregion

            }
            #endregion


        }

        #region Utilities

        private List<string> GetStateListWheat()
        {

            List<string> list = new List<string>();

            for (int ilayer = 0; ilayer < wheatLeafstate1_.State.Count; ilayer++)
            {

                switch (wheatLeafstate1_.State[ilayer])
                {
                    case 0:
                        list.Add("Growing");
                        break;
                    case 1:
                        list.Add("Mature");
                        break;
                    case 2:
                        list.Add("Senescing");
                        break;
                    case 3:
                        list.Add("Dead");
                        break;
                }
            }


            return list;
        }

        #endregion
    }
}
