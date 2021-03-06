/*
SQLyog Community v9.32 GA
MySQL - 5.5.40-0ubuntu0.14.04.1 
*********************************************************************
*/
/*!40101 SET NAMES utf8 */;

create table `countries` (
	`id` bigint (20),
	`tldList` blob ,
	`countryName` blob ,
	`countryCode` blob 
); 
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('1','','Germany','de');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('2','','United Kingdom','uk');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('3','','','com');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('4','','','net');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('5','','','biz');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('6','','','info');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('7','','','org');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('8','','Austria','at');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('9','','Tuvalu','tv');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('10','','Switzerland','ch');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('11','','Netherlands','nl');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('12','','United States','us');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('13','','Samoa','ws');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('14','','Italy','it');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('15','','Russian Federation','ru');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('16','','Belgium','be');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('17','','Poland','pl');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('18','','Brazil','br');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('19','','','name');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('20','','Cocos (Keeling) Islands','cc');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('21','','Tonga','to');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('22','','Tokelau','tk');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('23','','Antigua and Barbuda','ag');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('24','','Sweden','se');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('25','','France','fr');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('26','','Denmark','dk');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('27','','Romania','ro');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('28','','Czech Republic','cz');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('29','','Ascension Island','ac');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('30','','Montserrat','ms');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('31','','French Southern Territories','tf');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('32','','Turks and Caicos Islands','tc');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('33','','South Georgia and the South Sandwich Islands','gs');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('34','','Virgin Islands, British','vg');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('35','','Liechtenstein','li');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('36','','Armenia','am');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('37','','Greece','gr');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('38','','Portugal','pt');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('39','','Slovak Republic','sk');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('40','','Belarus','by');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('41','','Latvia','lv');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('42','','Lithuania','lt');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('43','','Andorra','ad');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('44','','Faroe Islands','fo');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('45','','Canada','ca');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('46','','Mexico','mx');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('47','','China','cn');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('48','','','edu');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('49','','','pro');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('50','','','mil');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('51','','Luxembourg','lu');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('52','','Christmas Island','cx');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('53','','Japan','jp');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('54','','Niue','nu');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('55','','Slovenia','si');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('56','','Australia','au');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('57','','Sao Tome and Principe','st');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('58','','Ukraine','ua');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('59','','','gov');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('60','','Ireland','ie');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('61','','Norway','no');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('62','','American Samoa','as');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('63','','Israel','il');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('64','','Belize','bz');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('65','','Chile','cl');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('66','','Korea, Republic of','kr');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('67','','Iceland','is');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('68','','Afghanistan','af');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('69','','','aero');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('70','','Saint Helena','sh');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('71','','Singapore','sg');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('72','','Turkmenistan','tm');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('73','','Benin','bj');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('74','','','cat');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('75','','Congo, The Democratic Republic of the','cd');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('76','','Cote d\\Ivoire','ci');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('77','','','coop');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('78','','Estonia','ee');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('79','','European Union','eu');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('80','','Finland','fi');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('81','','French Guiana','gf');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('82','','Guernsey','gg');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('83','','Jersey','je');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('84','','Hong Kong','hk');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('85','','Honduras','hn');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('86','','Seychelles','sc');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('87','','Saint Vincent and the Grenadines','vc');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('88','','Hungary','hu');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('89','','India','in');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('90','','','int');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('91','','British Indian Ocean Territory','io');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('92','','Kenya','ke');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('93','','Kazakhstan','kz');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('94','','Madagascar','mg');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('95','','Mongolia','mn');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('96','','','museum');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('97','','Malaysia','my');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('98','','Namibia','na');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('99','','New Zealand','nz');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('100','','Saint Pierre and Miquelon','pm');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('101','','Puerto Rico','pr');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('102','','Reunion Island','re');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('103','','Tajikistan','tj');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('104','','Timor-Leste','tl');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('105','','Turkey','tr');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('106','','Taiwan','tw');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('107','','Uganda','ug');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('108','','Uzbekistan','uz');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('109','','Venezuela','ve');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('110','','Wallis and Futuna Islands','wf');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('111','','Mayotte','yt');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('112','','Germany','de');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('113','','United Kingdom','uk');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('114','','','com');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('115','','','net');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('116','','','biz');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('117','','','info');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('118','','','org');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('119','','Austria','at');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('120','','Tuvalu','tv');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('121','','Switzerland','ch');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('122','','Netherlands','nl');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('123','','United States','us');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('124','','Samoa','ws');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('125','','Italy','it');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('126','','Russian Federation','ru');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('127','','Belgium','be');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('128','','Poland','pl');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('129','','Brazil','br');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('130','','','name');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('131','','Cocos (Keeling) Islands','cc');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('132','','Tonga','to');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('133','','Tokelau','tk');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('134','','Antigua and Barbuda','ag');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('135','','Sweden','se');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('136','','France','fr');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('137','','Denmark','dk');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('138','','Romania','ro');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('139','','Czech Republic','cz');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('140','','Ascension Island','ac');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('141','','Montserrat','ms');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('142','','French Southern Territories','tf');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('143','','Turks and Caicos Islands','tc');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('144','','South Georgia and the South Sandwich Islands','gs');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('145','','Virgin Islands, British','vg');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('146','','Liechtenstein','li');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('147','','Armenia','am');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('148','','Greece','gr');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('149','','Portugal','pt');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('150','','Slovak Republic','sk');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('151','','Belarus','by');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('152','','Latvia','lv');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('153','','Lithuania','lt');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('154','','Andorra','ad');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('155','','Faroe Islands','fo');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('156','','Canada','ca');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('157','','Mexico','mx');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('158','','China','cn');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('159','','','edu');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('160','','','pro');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('161','','','mil');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('162','','Luxembourg','lu');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('163','','Christmas Island','cx');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('164','','Japan','jp');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('165','','Niue','nu');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('166','','Slovenia','si');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('167','','Australia','au');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('168','','Sao Tome and Principe','st');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('169','','Ukraine','ua');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('170','','','gov');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('171','','Ireland','ie');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('172','','Norway','no');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('173','','American Samoa','as');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('174','','Israel','il');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('175','','Belize','bz');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('176','','Chile','cl');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('177','','Korea, Republic of','kr');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('178','','Iceland','is');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('179','','Afghanistan','af');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('180','','','aero');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('181','','Saint Helena','sh');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('182','','Singapore','sg');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('183','','Turkmenistan','tm');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('184','','Benin','bj');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('185','','','cat');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('186','','Congo, The Democratic Republic of the','cd');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('187','','Cote d\\Ivoire','ci');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('188','','','coop');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('189','','Estonia','ee');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('190','','European Union','eu');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('191','','Finland','fi');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('192','','French Guiana','gf');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('193','','Guernsey','gg');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('194','','Jersey','je');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('195','','Hong Kong','hk');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('196','','Honduras','hn');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('197','','Seychelles','sc');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('198','','Saint Vincent and the Grenadines','vc');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('199','','Hungary','hu');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('200','','India','in');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('201','','','int');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('202','','British Indian Ocean Territory','io');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('203','','Kenya','ke');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('204','','Kazakhstan','kz');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('205','','Madagascar','mg');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('206','','Mongolia','mn');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('207','','','museum');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('208','','Malaysia','my');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('209','','Namibia','na');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('210','','New Zealand','nz');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('211','','Saint Pierre and Miquelon','pm');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('212','','Puerto Rico','pr');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('213','','Reunion Island','re');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('214','','Tajikistan','tj');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('215','','Timor-Leste','tl');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('216','','Turkey','tr');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('217','','Taiwan','tw');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('218','','Uganda','ug');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('219','','Uzbekistan','uz');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('220','','Venezuela','ve');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('221','','Wallis and Futuna Islands','wf');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('222','','Mayotte','yt');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('223','','Germany','de');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('224','','United Kingdom','uk');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('225','','','com');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('226','','','net');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('227','','','biz');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('228','','','info');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('229','','','org');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('230','','Austria','at');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('231','','Tuvalu','tv');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('232','','Switzerland','ch');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('233','','Netherlands','nl');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('234','','United States','us');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('235','','Samoa','ws');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('236','','Italy','it');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('237','','Russian Federation','ru');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('238','','Belgium','be');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('239','','Poland','pl');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('240','','Brazil','br');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('241','','','name');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('242','','Cocos (Keeling) Islands','cc');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('243','','Tonga','to');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('244','','Tokelau','tk');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('245','','Antigua and Barbuda','ag');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('246','','Sweden','se');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('247','','France','fr');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('248','','Denmark','dk');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('249','','Romania','ro');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('250','','Czech Republic','cz');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('251','','Ascension Island','ac');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('252','','Montserrat','ms');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('253','','French Southern Territories','tf');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('254','','Turks and Caicos Islands','tc');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('255','','South Georgia and the South Sandwich Islands','gs');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('256','','Virgin Islands, British','vg');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('257','','Liechtenstein','li');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('258','','Armenia','am');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('259','','Greece','gr');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('260','','Portugal','pt');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('261','','Slovak Republic','sk');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('262','','Belarus','by');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('263','','Latvia','lv');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('264','','Lithuania','lt');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('265','','Andorra','ad');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('266','','Faroe Islands','fo');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('267','','Canada','ca');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('268','','Mexico','mx');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('269','','China','cn');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('270','','','edu');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('271','','','pro');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('272','','','mil');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('273','','Luxembourg','lu');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('274','','Christmas Island','cx');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('275','','Japan','jp');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('276','','Niue','nu');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('277','','Slovenia','si');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('278','','Australia','au');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('279','','Sao Tome and Principe','st');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('280','','Ukraine','ua');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('281','','','gov');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('282','','Ireland','ie');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('283','','Norway','no');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('284','','American Samoa','as');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('285','','Israel','il');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('286','','Belize','bz');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('287','','Chile','cl');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('288','','Korea, Republic of','kr');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('289','','Iceland','is');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('290','','Afghanistan','af');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('291','','','aero');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('292','','Saint Helena','sh');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('293','','Singapore','sg');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('294','','Turkmenistan','tm');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('295','','Benin','bj');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('296','','','cat');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('297','','Congo, The Democratic Republic of the','cd');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('298','','Cote dIvoire','ci');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('299','','','coop');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('300','','Estonia','ee');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('301','','European Union','eu');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('302','','Finland','fi');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('303','','French Guiana','gf');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('304','','Guernsey','gg');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('305','','Jersey','je');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('306','','Hong Kong','hk');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('307','','Honduras','hn');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('308','','Seychelles','sc');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('309','','Saint Vincent and the Grenadines','vc');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('310','','Hungary','hu');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('311','','India','in');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('312','','','int');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('313','','British Indian Ocean Territory','io');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('314','','Kenya','ke');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('315','','Kazakhstan','kz');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('316','','Madagascar','mg');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('317','','Mongolia','mn');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('318','','','museum');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('319','','Malaysia','my');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('320','','Namibia','na');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('321','','New Zealand','nz');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('322','','Saint Pierre and Miquelon','pm');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('323','','Puerto Rico','pr');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('324','','Reunion Island','re');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('325','','Tajikistan','tj');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('326','','Timor-Leste','tl');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('327','','Turkey','tr');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('328','','Taiwan','tw');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('329','','Uganda','ug');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('330','','Uzbekistan','uz');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('331','','Venezuela','ve');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('332','','Wallis and Futuna Islands','wf');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('333','','Mayotte','yt');
insert into `countries` (`id`, `tldList`, `countryName`, `countryCode`) values('334',NULL,'Serbia','rs');
