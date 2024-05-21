create table pelanggan (
	"KODE" varchar(11) primary key,
	"NAMA" varchar(255), 
	"ALAMAT" varchar(255));
	
insert into pelanggan("KODE", "NAMA", "ALAMAT") values
('P1', 'Yogi', 'JAKARTA'),
('P2', 'Anggi', 'BANDUNG'),
('P3', 'Rahma', 'BANDUNG');

select * from pelanggan;

create table barang (
	"KODE" varchar(255) primary key, 
	"NAMA" varchar(255), 
	"HARGA" decimal(255,0));
	
insert into barang ("KODE", "NAMA", "HARGA") values
('B1', 'Baju', 12000),
('B2', 'Celana', 10000),
('B3', 'Sepatu', 30000);

select * from barang;

create table transaksi(
	"KODE" varchar(255) primary key, 
	"TANGGAL" date, 
	"KODE_PELANGGAN" varchar(255) references pelanggan("KODE"), 
	"KODE_BARANG" varchar(255) references barang("KODE"), 
	"JUMLAH_BARANG" decimal(255,0));
	
insert into transaksi("KODE", "TANGGAL", "KODE_PELANGGAN", "KODE_BARANG", "JUMLAH_BARANG") values 
('TRX001', '2019-10-02', 'P1', 'B1', 3),
('TRX002', '2019-10-02', 'P2', 'B2', 2),
('TRX003', '2019-10-08', 'P2', 'B1', 5),
('TRX004', '2019-10-10', 'P1', 'B1', 1),
('TRX005', '2019-10-17', 'P3', 'B3', 2),
('TRX006', '2019-10-17', 'P2', 'B3', 1),
('TRX007', '2019-10-18', 'P3', 'B1', 4),
('TRX008', '2019-10-18', 'P2', 'B2', 2);

select * from transaksi;

-- Sub a
select * from barang where "HARGA" > 10000 order by "HARGA" asc;

-- Sub b
select * from pelanggan where lower("NAMA") like '%g%' and "ALAMAT" = 'BANDUNG';

-- Sub c
select t."KODE", t."TANGGAL", p."NAMA" as "NAMA PELANGGAN", b."NAMA" as "NAMA BARANG", t."JUMLAH_BARANG" as JUMLAH, b."HARGA" as "HARGA SATUAN", (b."HARGA" * t."JUMLAH_BARANG") as TOTAL from transaksi t 
	join barang b on b."KODE" = t."KODE_BARANG"
	join pelanggan p on p."KODE" = t."KODE_PELANGGAN" 
	order by p."NAMA", t."TANGGAL";
	
-- Sub d
select p."NAMA" as "NAMA PELANGGAN", sum(t."JUMLAH_BARANG") as JUMLAH, sum(t."JUMLAH_BARANG" * b."HARGA") as "TOTAL HARGA" from transaksi t
	join barang  b on b."KODE" = t."KODE_BARANG" 
	join pelanggan p on p."KODE" = t."KODE_PELANGGAN" 
	group by p."NAMA" 
	order by p."NAMA";