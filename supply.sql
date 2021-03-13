-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 11, 2021 at 03:30 PM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `supply`
--

-- --------------------------------------------------------

--
-- Table structure for table `brand`
--

CREATE TABLE `brand` (
  `brand_id` int(11) NOT NULL,
  `brand_name` varchar(50) NOT NULL,
  `date_created` datetime DEFAULT NULL,
  `date_updated` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `brand`
--

INSERT INTO `brand` (`brand_id`, `brand_name`, `date_created`, `date_updated`) VALUES
(1, 'Frutta cool', '2021-03-11 21:10:30', '2021-03-11 21:13:36'),
(2, 'Vapor Crave', '2021-03-11 21:10:30', NULL),
(3, 'Marvel', '2021-03-11 21:10:30', NULL),
(4, 'Classico', '2021-03-11 21:10:30', NULL),
(5, 'Espesyal Vapors', '2021-03-11 21:10:30', NULL),
(6, 'Drppn', '2021-03-11 21:10:30', NULL),
(7, 'Pastry  Vapor', '2021-03-11 21:10:30', NULL),
(8, 'Demon Vape', '2021-03-11 21:10:30', NULL),
(9, 'Drip Squad', '2021-03-11 21:10:30', NULL),
(10, 'Dr. Fog', '2021-03-11 21:10:30', '2021-03-11 21:24:25'),
(11, 'Dr. Freeze', '2021-03-11 21:10:30', NULL),
(12, 'Dr. Clouds', '2021-03-11 21:10:30', NULL),
(13, 'Smoke All Fame Freeze', '2021-03-11 21:10:30', NULL),
(14, 'Big bang', '2021-03-11 21:10:30', NULL),
(15, 'Dreadtac', '2021-03-11 21:10:30', NULL),
(16, 'Hell Vape', '2021-03-11 21:10:30', NULL),
(17, 'Geek Vape', '2021-03-11 21:10:30', NULL),
(18, 'Rincoe', '2021-03-11 21:10:30', NULL),
(19, 'Wick n Vape', '2021-03-11 21:10:30', NULL),
(20, 'N90', '2021-03-11 21:10:30', NULL),
(21, 'Dr. Coil', '2021-03-11 21:10:30', NULL),
(22, 'Daily Clouds', '2021-03-11 21:10:30', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `cancel_sales`
--

CREATE TABLE `cancel_sales` (
  `cancelSales_id` int(11) NOT NULL,
  `transaction_id` int(11) DEFAULT NULL,
  `products_id` varchar(20) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `date_cancel` varchar(25) DEFAULT NULL,
  `voidby` varchar(50) DEFAULT NULL,
  `cancelBy` varchar(50) DEFAULT NULL,
  `reason` text DEFAULT NULL,
  `action` varchar(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `category_id` int(11) NOT NULL,
  `category_name` varchar(100) NOT NULL,
  `date_created` datetime DEFAULT NULL,
  `date_updated` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`category_id`, `category_name`, `date_created`, `date_updated`) VALUES
(1, 'e-juice', '2021-03-11 21:10:19', NULL),
(2, 'Attomizer', '2021-03-11 21:29:45', NULL),
(3, 'mod', '2021-03-11 21:29:45', NULL),
(4, 'pod', '2021-03-11 21:29:45', NULL),
(5, 'cotton', '2021-03-11 21:29:45', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `products_id` varchar(20) NOT NULL,
  `barcode` varchar(15) DEFAULT NULL,
  `product_name` varchar(50) NOT NULL,
  `category_id` int(11) NOT NULL,
  `brand_id` int(11) NOT NULL,
  `description` text DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `price` decimal(18,2) DEFAULT NULL,
  `reorder` int(11) DEFAULT NULL,
  `date_created` datetime DEFAULT NULL,
  `date_updated` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`products_id`, `barcode`, `product_name`, `category_id`, `brand_id`, `description`, `quantity`, `price`, `reorder`, `date_created`, `date_updated`) VALUES
('P-00120', '111159330513', 'Pistachio Nuts', 1, 5, '6mg', 45, '200.00', 0, '2021-03-11 21:28:44', NULL),
('P-00141', '111195540397', 'Chilled Lychee', 1, 13, '3mg', 49, '200.00', 0, '2021-03-11 21:27:36', NULL),
('P-00158', '111177064004', 'Zeus X', 2, 17, 'RTA 1:1', 50, '400.00', 0, '2021-03-11 21:31:20', NULL),
('P-00166', '111191984411', 'Winter Grapes', 1, 12, '3mg', 49, '200.00', 0, '2021-03-11 21:23:32', NULL),
('P-0022', '111108988994', 'Milky Beam', 1, 6, '3mg', 50, '130.00', 0, '2021-03-11 21:16:02', NULL),
('P-00233', '111122587152', 'Jellybox', 3, 18, 'Amber Clear', 50, '1500.00', 0, '2021-03-11 21:35:04', NULL),
('P-00237', '111156270504', 'Fruti Ice Pop', 1, 2, '3mg', 50, '300.00', 0, '2021-03-11 21:14:35', NULL),
('P-00256', '111116677400', 'Cleopatra', 1, 6, '6mg', 50, '130.00', 0, '2021-03-11 21:21:38', NULL),
('P-00311', '111118277016', 'Avocado Melon', 1, 5, '3mg', 50, '200.00', 0, '2021-03-11 21:15:40', NULL),
('P-00358', '111102809581', 'Chocolate', 1, 5, '6mg', 50, '200.00', 0, '2021-03-11 21:29:10', NULL),
('P-00360', '111195732549', 'White Rabbit', 1, 10, '3mg', 50, '200.00', 0, '2021-03-11 21:26:46', NULL),
('P-0042', '111112227446', 'Strawberry Ice Cream', 1, 14, '3mg', 50, '200.00', 0, '2021-03-11 21:28:03', NULL),
('P-0045', '111139791893', 'Korean Desser', 1, 15, '3mg', 50, '200.00', 0, '2021-03-11 21:28:24', NULL),
('P-00470', '111134872977', 'Stawberry Ice cream', 1, 3, '3mg', 50, '200.00', 0, '2021-03-11 21:15:15', NULL),
('P-00533', '111147827577', 'Capuccino Delight', 1, 10, '3mg', 50, '200.00', 0, '2021-03-11 21:23:54', '2021-03-11 21:24:56'),
('P-00577', '111194951275', 'Grape Slush', 1, 13, '3mg', 50, '200.00', 0, '2021-03-11 21:27:11', NULL),
('P-0062', '111177121959', 'Nerdz', 1, 11, '3mg', 50, '200.00', 0, '2021-03-11 21:20:17', NULL),
('P-00638', '111159679560', 'Cranberry Cheesecake', 1, 9, '3mg', 50, '150.00', 0, '2021-03-11 21:17:16', NULL),
('P-00689', '111139993962', 'Sprites', 1, 8, '3mg', 50, '130.00', 0, '2021-03-11 21:26:21', NULL),
('P-00742', '111106256009', 'Frozen Yogurt', 1, 12, '3mg', 50, '200.00', 0, '2021-03-11 21:23:10', NULL),
('P-00750', '111172728572', 'Aegis Boost', 4, 17, 'Luxury Edition', 50, '1500.00', 0, '2021-03-11 21:34:31', NULL),
('P-00753', '111110656608', 'Dark Elixir', 1, 1, '3mg', 50, '200.00', 0, '2021-03-11 21:13:46', NULL),
('P-0077', '111183831666', 'Frozen Lychee', 1, 10, '3mg', 50, '200.00', 0, '2021-03-11 21:17:47', NULL),
('P-00796', '111117942798', 'Strawberry Ice', 1, 11, '3mg', 50, '200.00', 0, '2021-03-11 21:22:50', NULL),
('P-00799', '111179769207', 'Melon Pan', 1, 7, '3mg', 50, '150.00', 0, '2021-03-11 21:16:22', NULL),
('P-00800', '111111257203', 'Rootbeer Float', 1, 8, '3mg', 50, '130.00', 0, '2021-03-11 21:25:08', NULL),
('P-00843', '111176790295', 'RY4 Creme Brulee', 1, 7, '20mg', 50, '250.00', 0, '2021-03-11 21:20:46', '2021-03-11 21:21:30'),
('P-00854', '111184442631', 'Fruitopia', 1, 8, '3mg', 50, '130.00', 0, '2021-03-11 21:16:42', NULL),
('P-00864', '111118181490', 'Drop', 2, 16, 'RDA 24MM 1:1', 50, '350.00', 0, '2021-03-11 21:30:30', NULL),
('P-00891', '111170129820', 'Energy', 1, 8, '3mg', 50, '130.00', 0, '2021-03-11 21:25:58', NULL),
('P-00928', '111109107101', 'Cotton Bacon', 5, 19, 'Premium Cotton', 50, '120.00', 0, '2021-03-11 21:35:34', NULL),
('P-00991', '111128832812', 'Drop Dead', 2, 16, 'RDA 24MM 1:1', 50, '350.00', 0, '2021-03-11 21:30:50', NULL),
('P-00993', '111111912667', 'Twinkles', 1, 7, '20mg', 50, '250.00', 3, '2021-03-11 21:20:33', '2021-03-11 21:21:13');

-- --------------------------------------------------------

--
-- Table structure for table `stocks`
--

CREATE TABLE `stocks` (
  `stock_id` int(11) NOT NULL,
  `referenceNo` int(11) DEFAULT NULL,
  `products_id` varchar(20) NOT NULL,
  `stockDATE` varchar(25) DEFAULT NULL,
  `stockInBy` varchar(60) DEFAULT NULL,
  `status` varchar(20) DEFAULT NULL,
  `vendor_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `stocks`
--

INSERT INTO `stocks` (`stock_id`, `referenceNo`, `products_id`, `stockDATE`, `stockInBy`, `status`, `vendor_id`) VALUES
(6, 2147483647, 'P-00112', '3/11/2021', 'Admin', 'Functioning', 1),
(7, 2147483647, 'P-00120', '3/11/2021', 'Admin', NULL, 1),
(8, 2147483647, 'P-00141', '3/11/2021', 'Admin', NULL, 1),
(9, 2147483647, 'P-00158', '3/11/2021', 'Admin', NULL, 1),
(10, 2147483647, 'P-00166', '3/11/2021', 'Admin', NULL, 1),
(11, 2147483647, 'P-0022', '3/11/2021', 'Admin', NULL, 1),
(12, 2147483647, 'P-00233', '3/11/2021', 'Admin', NULL, 1),
(13, 2147483647, 'P-00237', '3/11/2021', 'Admin', NULL, 1),
(14, 2147483647, 'P-00256', '3/11/2021', 'Admin', NULL, 1),
(15, 2147483647, 'P-00311', '3/11/2021', 'Admin', NULL, 1),
(16, 2147483647, 'P-00358', '3/11/2021', 'Admin', NULL, 1),
(17, 2147483647, 'P-00360', '3/11/2021', 'Admin', NULL, 1),
(18, 2147483647, 'P-0042', '3/11/2021', 'Admin', NULL, 1),
(19, 2147483647, 'P-0045', '3/11/2021', 'Admin', NULL, 1),
(20, 2147483647, 'P-00470', '3/11/2021', 'Admin', NULL, 1),
(21, 2147483647, 'P-00490', '3/11/2021', 'Admin', NULL, 1),
(22, 2147483647, 'P-005', '3/11/2021', 'Admin', NULL, 1),
(23, 2147483647, 'P-00533', '3/11/2021', 'Admin', NULL, 1),
(24, 2147483647, 'P-00577', '3/11/2021', 'Admin', NULL, 1),
(25, 2147483647, 'P-0062', '3/11/2021', 'Admin', NULL, 1),
(26, 2147483647, 'P-00638', '3/11/2021', 'Admin', NULL, 1),
(27, 2147483647, 'P-00689', '3/11/2021', 'Admin', NULL, 1),
(28, 2147483647, 'P-00742', '3/11/2021', 'Admin', NULL, 1),
(29, 2147483647, 'P-00745', '3/11/2021', 'Admin', NULL, 1),
(30, 2147483647, 'P-00750', '3/11/2021', 'Admin', NULL, 1),
(31, 2147483647, 'P-00753', '3/11/2021', 'Admin', NULL, 1),
(32, 2147483647, 'P-0077', '3/11/2021', 'Admin', NULL, 1),
(33, 2147483647, 'P-00796', '3/11/2021', 'Admin', NULL, 1),
(34, 2147483647, 'P-00799', '3/11/2021', 'Admin', NULL, 1),
(35, 2147483647, 'P-00800', '3/11/2021', 'Admin', NULL, 1),
(36, 2147483647, 'P-00843', '3/11/2021', 'Admin', NULL, 1),
(37, 2147483647, 'P-00854', '3/11/2021', 'Admin', NULL, 1),
(38, 2147483647, 'P-00864', '3/11/2021', 'Admin', NULL, 1),
(39, 2147483647, 'P-00891', '3/11/2021', 'Admin', NULL, 1),
(40, 2147483647, 'P-00928', '3/11/2021', 'Admin', NULL, 1),
(41, 2147483647, 'P-00936', '3/11/2021', 'Admin', NULL, 1),
(42, 2147483647, 'P-00991', '3/11/2021', 'Admin', NULL, 1),
(43, 2147483647, 'P-00993', '3/11/2021', 'Admin', NULL, 1);

-- --------------------------------------------------------

--
-- Table structure for table `stock_adjustment`
--

CREATE TABLE `stock_adjustment` (
  `stock_adjustment_id` int(11) NOT NULL,
  `referenceNo` int(11) DEFAULT NULL,
  `products_id` varchar(20) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `action` varchar(20) DEFAULT NULL,
  `remarks` text DEFAULT NULL,
  `users` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `stock_adjustment`
--

INSERT INTO `stock_adjustment` (`stock_adjustment_id`, `referenceNo`, `products_id`, `quantity`, `action`, `remarks`, `users`) VALUES
(9, 2147483647, 'P-00120', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(10, 2147483647, 'P-00141', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(11, 2147483647, 'P-00166', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(12, 2147483647, 'P-0022', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(13, 2147483647, 'P-00237', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(14, 2147483647, 'P-00256', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(15, 2147483647, 'P-00311', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(16, 2147483647, 'P-00358', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(17, 2147483647, 'P-00360', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(18, 2147483647, 'P-0042', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(19, 2147483647, 'P-0045', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(20, 2147483647, 'P-00470', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(21, 2147483647, 'P-00533', 50, 'ADD TO INVENTORY', 'Adding', 'admin'),
(22, 2147483647, 'P-00577', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(23, 2147483647, 'P-0062', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(24, 2147483647, 'P-00638', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(25, 2147483647, 'P-00689', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(26, 2147483647, 'P-00742', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(27, 2147483647, 'P-00753', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(28, 2147483647, 'P-0077', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(29, 2147483647, 'P-00796', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(30, 2147483647, 'P-00799', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(31, 2147483647, 'P-00800', 50, 'ADD TO INVENTORY', 'adding', 'admin'),
(32, 2147483647, 'P-00843', 50, 'ADD TO INVENTORY', 'adding', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `transaction`
--

CREATE TABLE `transaction` (
  `transaction_id` int(11) NOT NULL,
  `transactionNo` varchar(15) DEFAULT NULL,
  `products_id` varchar(20) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `discount_percent` decimal(18,2) DEFAULT NULL,
  `discount` decimal(18,2) DEFAULT NULL,
  `total` decimal(18,2) DEFAULT NULL,
  `cashier` varchar(30) DEFAULT NULL,
  `date_created` date DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `transaction`
--

INSERT INTO `transaction` (`transaction_id`, `transactionNo`, `products_id`, `quantity`, `discount_percent`, `discount`, `total`, `cashier`, `date_created`, `status`) VALUES
(2, '11430120210311', 'P-00120', 2, '0.50', '200.00', '200.00', 'cashier', '2021-03-11', 'approve'),
(3, '11430120210311', 'P-00141', 1, NULL, '0.00', '200.00', 'cashier', '2021-03-11', 'approve'),
(4, '11430120210311', 'P-00166', 1, NULL, '0.00', '200.00', 'cashier', '2021-03-11', 'approve'),
(5, '36078120210311', 'P-00120', 1, NULL, '0.00', '200.00', 'cashier', '2021-03-11', 'approve'),
(6, '29249720210311', 'P-00120', 1, NULL, '0.00', '200.00', 'cashier', '2021-03-11', 'approve'),
(7, '75408220210311', 'P-00120', 1, NULL, '0.00', '200.00', 'cashier', '2021-03-11', 'approve');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `fname` varchar(100) NOT NULL,
  `mname` varchar(100) NOT NULL,
  `lname` varchar(100) NOT NULL,
  `address` text DEFAULT NULL,
  `age` int(3) NOT NULL,
  `gender` varchar(7) NOT NULL,
  `usertype` varchar(20) DEFAULT NULL,
  `date_created` datetime DEFAULT NULL,
  `date_updated` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `username`, `password`, `fname`, `mname`, `lname`, `address`, `age`, `gender`, `usertype`, `date_created`, `date_updated`) VALUES
('11851202020', 'cashier', 'cashier', 'Drilon', 'Ian', 'Adorable', 'Brgy. Bolong Este Santa Barbara Iloilo', 20, 'Male', 'Employee', '2020-03-17 23:05:49', NULL),
('68761652020', 'admin', 'admin', 'Ian', 'A', 'Drilon', 'Brgy. Bolong Este', 20, 'Male', 'Admin', '2020-04-04 14:12:10', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `vatable`
--

CREATE TABLE `vatable` (
  `vat_id` int(11) NOT NULL,
  `vat` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `vatable`
--

INSERT INTO `vatable` (`vat_id`, `vat`) VALUES
(1, 0.12);

-- --------------------------------------------------------

--
-- Table structure for table `vendor`
--

CREATE TABLE `vendor` (
  `vendor_id` int(11) NOT NULL,
  `vendor` varchar(100) DEFAULT NULL,
  `address` text DEFAULT NULL,
  `contactPerson` varchar(50) DEFAULT NULL,
  `telephoneNo` varchar(13) DEFAULT NULL,
  `email` varchar(20) DEFAULT NULL,
  `fax` varchar(13) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `vendor`
--

INSERT INTO `vendor` (`vendor_id`, `vendor`, `address`, `contactPerson`, `telephoneNo`, `email`, `fax`) VALUES
(1, 'blue', 'santa barbara', '09123456789', '123-561-231', 'bluegreen@gmail.com', ''),
(2, 'green', 'green blue red', '09876543211', '123-671-213', 'greenblue@gmail.com', '');

-- --------------------------------------------------------

--
-- Stand-in structure for view `viewcance_sales`
-- (See below for the actual view)
--
CREATE TABLE `viewcance_sales` (
`cancelSales_id` int(11)
,`transaction_id` int(11)
,`products_id` varchar(20)
,`description` text
,`price` decimal(18,2)
,`quantity` int(11)
,`total` decimal(28,2)
,`date_cancel` varchar(25)
,`voidby` varchar(50)
,`cancelBy` varchar(50)
,`reason` text
,`action` varchar(5)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `viewcriticalitems`
-- (See below for the actual view)
--
CREATE TABLE `viewcriticalitems` (
`products_id` varchar(20)
,`barcode` varchar(15)
,`product_name` varchar(50)
,`category_name` varchar(100)
,`brand_name` varchar(50)
,`description` text
,`price` decimal(18,2)
,`reorder` int(11)
,`quantity` int(11)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `viewproductinventory`
-- (See below for the actual view)
--
CREATE TABLE `viewproductinventory` (
`products_id` varchar(20)
,`barcode` varchar(15)
,`product_name` varchar(50)
,`category_name` varchar(100)
,`brand_name` varchar(50)
,`description` text
,`price` decimal(18,2)
,`reorder` int(11)
,`quantity` int(11)
);

-- --------------------------------------------------------

--
-- Structure for view `viewcance_sales`
--
DROP TABLE IF EXISTS `viewcance_sales`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `viewcance_sales`  AS  select `c`.`cancelSales_id` AS `cancelSales_id`,`t`.`transaction_id` AS `transaction_id`,`t`.`products_id` AS `products_id`,`p`.`description` AS `description`,`p`.`price` AS `price`,`c`.`quantity` AS `quantity`,`c`.`quantity` * `p`.`price` AS `total`,`c`.`date_cancel` AS `date_cancel`,`c`.`voidby` AS `voidby`,`c`.`cancelBy` AS `cancelBy`,`c`.`reason` AS `reason`,`c`.`action` AS `action` from ((`cancel_sales` `c` join `product` `p` on(`p`.`products_id` = `c`.`products_id`)) join `transaction` `t` on(`t`.`transaction_id` = `c`.`transaction_id`)) ;

-- --------------------------------------------------------

--
-- Structure for view `viewcriticalitems`
--
DROP TABLE IF EXISTS `viewcriticalitems`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `viewcriticalitems`  AS  select `p`.`products_id` AS `products_id`,`p`.`barcode` AS `barcode`,`p`.`product_name` AS `product_name`,`c`.`category_name` AS `category_name`,`b`.`brand_name` AS `brand_name`,`p`.`description` AS `description`,`p`.`price` AS `price`,`p`.`reorder` AS `reorder`,`p`.`quantity` AS `quantity` from ((`product` `p` join `category` `c` on(`c`.`category_id` = `p`.`category_id`)) join `brand` `b` on(`b`.`brand_id` = `p`.`brand_id`)) where `p`.`quantity` <= `p`.`reorder` ;

-- --------------------------------------------------------

--
-- Structure for view `viewproductinventory`
--
DROP TABLE IF EXISTS `viewproductinventory`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `viewproductinventory`  AS  select `p`.`products_id` AS `products_id`,`p`.`barcode` AS `barcode`,`p`.`product_name` AS `product_name`,`c`.`category_name` AS `category_name`,`b`.`brand_name` AS `brand_name`,`p`.`description` AS `description`,`p`.`price` AS `price`,`p`.`reorder` AS `reorder`,`p`.`quantity` AS `quantity` from ((`product` `p` join `category` `c` on(`c`.`category_id` = `p`.`category_id`)) join `brand` `b` on(`b`.`brand_id` = `p`.`brand_id`)) ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `brand`
--
ALTER TABLE `brand`
  ADD PRIMARY KEY (`brand_id`);

--
-- Indexes for table `cancel_sales`
--
ALTER TABLE `cancel_sales`
  ADD PRIMARY KEY (`cancelSales_id`),
  ADD KEY `transaction_id` (`transaction_id`),
  ADD KEY `products_id` (`products_id`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`category_id`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`products_id`),
  ADD KEY `category_id` (`category_id`),
  ADD KEY `brand_id` (`brand_id`);

--
-- Indexes for table `stocks`
--
ALTER TABLE `stocks`
  ADD PRIMARY KEY (`stock_id`),
  ADD KEY `products_id` (`products_id`),
  ADD KEY `vendor_id` (`vendor_id`);

--
-- Indexes for table `stock_adjustment`
--
ALTER TABLE `stock_adjustment`
  ADD PRIMARY KEY (`stock_adjustment_id`),
  ADD KEY `products_id` (`products_id`);

--
-- Indexes for table `transaction`
--
ALTER TABLE `transaction`
  ADD PRIMARY KEY (`transaction_id`),
  ADD KEY `products_id` (`products_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`);

--
-- Indexes for table `vatable`
--
ALTER TABLE `vatable`
  ADD PRIMARY KEY (`vat_id`);

--
-- Indexes for table `vendor`
--
ALTER TABLE `vendor`
  ADD PRIMARY KEY (`vendor_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `brand`
--
ALTER TABLE `brand`
  MODIFY `brand_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT for table `cancel_sales`
--
ALTER TABLE `cancel_sales`
  MODIFY `cancelSales_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `category_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `stocks`
--
ALTER TABLE `stocks`
  MODIFY `stock_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=44;

--
-- AUTO_INCREMENT for table `stock_adjustment`
--
ALTER TABLE `stock_adjustment`
  MODIFY `stock_adjustment_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT for table `transaction`
--
ALTER TABLE `transaction`
  MODIFY `transaction_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `vatable`
--
ALTER TABLE `vatable`
  MODIFY `vat_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `vendor`
--
ALTER TABLE `vendor`
  MODIFY `vendor_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `product_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `category` (`category_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `product_ibfk_2` FOREIGN KEY (`brand_id`) REFERENCES `brand` (`brand_id`) ON DELETE CASCADE;

--
-- Constraints for table `stock_adjustment`
--
ALTER TABLE `stock_adjustment`
  ADD CONSTRAINT `stock_adjustment_ibfk_1` FOREIGN KEY (`products_id`) REFERENCES `product` (`products_id`);

--
-- Constraints for table `transaction`
--
ALTER TABLE `transaction`
  ADD CONSTRAINT `transaction_ibfk_1` FOREIGN KEY (`products_id`) REFERENCES `product` (`products_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
