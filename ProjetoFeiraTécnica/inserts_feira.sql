create database MapaFeira_db;
use MapaFeira_db;


create table  Salas (
	id int not null auto_increment primary key,
    Sala varchar(45) not null,
    Curso varchar(45) not null,
    Ano varchar(45) not null,
    Mapa varchar(200) not null,
	referencia varchar(200) not null,
    video varchar(100) 
);

select * from salas order by ano;


INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (1,'3','eletronica','primeiro ano de eletronica','.//Imagens//sala3.png',".//Imagens//referencias//referência-Sala03.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (2,'2','administração','primeiro ano de administração','.//Imagens//sala2.png',".//Imagens//referencias//referência-Sala02.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (3,'9','eletronica','segundo ano de eletronica','.//Imagens//sala9.png',".//Imagens//referencias//referência-Sala09.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (4,'Corredor','eletronica','terceiro ano de eletronica','.//Imagens//Finalcorredor.png',".//Imagens//referencias//referência-Corredor1.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (5,'Corredor','analises clinicas','terceiro ano de analises clinicas','.//Imagens//piso1corredor.gif',".//Imagens//referencias//referência-Corredor2.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (6,'12','analises clinicas','primeiro ano de analises clinicas','.//Imagens//piso1sala12.gif',".//Imagens//referencias//referência-Sala12.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (7,'11','analises clinicas','segundo ano de analises clinicas','.//Imagens//piso1sala11.gif',".//Imagens//referencias//referência-Sala11.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (8,'16','analises clinicas','primeiro ano de analises clinicas','.//Imagens//piso1sala16.gif',".//Imagens//referencias//referência-Sala16.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (9,'13','quimica','terceiro ano de quimica','.//Imagens//piso1corredor.gif',".//Imagens//referencias//referência-Corredor2.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (10,'13','quimica','segundo ano de quimica','.//Imagens//piso1sala13.gif',".//Imagens//referencias//referência-Sala13.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (11,'19','quimica','primeiro ano de quimica','.//Imagens//piso1sala19.gif',".//Imagens//referencias//referência-Sala19.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (12,'22','publicidade','segundo ano de publicidade','.//Imagens//piso2sala22.gif',".//Imagens//referencias//referência-Sala22.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (13,'Corredor','admistração','terceiro ano de administração','.//Imagens//piso2corredor.gif',".//Imagens//referencias//referência-Corredor3.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (14,'Corredor','informática','terceiro ano de informática','.//Imagens//piso2corredor.gif',".//Imagens//referencias//referência-Corredor3.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (15,'Corredor','publicidade','terceiro ano de publicidade','.//Imagens//piso2corredor.gif',".//Imagens//referencias//referência-Corredor3.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (16,'27','publicidade','primeiro ano de publicidade','.//Imagens//piso2sala27.gif',".//Imagens//referencias//referência-Sala27.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (17,'23','informatica','segundo ano de informatica','.//Imagens//piso2sala23.gif',".//Imagens//referencias//referência-Sala23.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (18,'28','informatica','segundo ano de informatica','.//Imagens//piso2sala28.gif',".//Imagens//referencias//referência-Sala28.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (19,'28','informatica','primeiro ano de informatica','.//Imagens//piso2sala28.gif',".//Imagens//referencias//referência-Sala28.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (20,'23','informatica','primeiro ano de informatica','.//Imagens//piso2sala23.gif',".//Imagens//referencias//referência-Sala23.jpg",NULL);
INSERT INTO `Salas` (`id`,`Sala`,`curso`,`ano`,`Mapa`,`referencia`,`Video`) VALUES (21,'29','administração','segundo ano de administração','.//Imagens//piso2sala29.gif',".//Imagens//referencias//referência-Sala29.jpg",NULL);
