-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 24, 2022 at 07:58 AM
-- Server version: 8.0.30
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
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
  `brand_id` int NOT NULL,
  `brand_name` varchar(50) NOT NULL,
  `date_created` datetime DEFAULT NULL,
  `date_updated` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `brand`
--

INSERT INTO `brand` (`brand_id`, `brand_name`, `date_created`, `date_updated`) VALUES
(24, 'N/A', '2022-11-15 18:10:51', '2022-11-16 10:26:21');

-- --------------------------------------------------------

--
-- Table structure for table `cancel_sales`
--

CREATE TABLE `cancel_sales` (
  `cancelSales_id` int NOT NULL,
  `transaction_id` int DEFAULT NULL,
  `products_id` varchar(20) DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `date_cancel` varchar(25) DEFAULT NULL,
  `voidby` varchar(50) DEFAULT NULL,
  `cancelBy` varchar(50) DEFAULT NULL,
  `reason` text,
  `action` varchar(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `category_id` int NOT NULL,
  `category_name` varchar(100) NOT NULL,
  `date_created` datetime DEFAULT NULL,
  `date_updated` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`category_id`, `category_name`, `date_created`, `date_updated`) VALUES
(7, 'VALVE REDUCER PRESTA/SHRADER', '2022-11-15 18:08:56', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `products_id` varchar(20) NOT NULL,
  `barcode` varchar(15) DEFAULT NULL,
  `product_name` varchar(50) NOT NULL,
  `category_id` int NOT NULL,
  `brand_id` int NOT NULL,
  `description` text,
  `quantity` int DEFAULT NULL,
  `price` decimal(18,2) DEFAULT NULL,
  `reorder` int DEFAULT NULL,
  `capital` int DEFAULT NULL,
  `gain` int DEFAULT NULL,
  `percentage` double DEFAULT NULL,
  `date_created` datetime DEFAULT NULL,
  `date_updated` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`products_id`, `barcode`, `product_name`, `category_id`, `brand_id`, `description`, `quantity`, `price`, `reorder`, `capital`, `gain`, `percentage`, `date_created`, `date_updated`) VALUES
('P-00728', '111105440245', 'Valve Adaptor Gold', 7, 24, 'valve adaptor gold', 48, '500.00', 0, 200, 300, 2.5, '2022-11-15 18:29:50', '2022-11-17 20:01:15'),
('P-00738', '111197649628', 'dawda', 7, 24, 'dawad', 0, '500.00', 0, 200, 300, 2.5, '2022-11-17 20:34:31', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `stocks`
--

CREATE TABLE `stocks` (
  `stock_id` int NOT NULL,
  `referenceNo` bigint DEFAULT NULL,
  `products_id` varchar(20) NOT NULL,
  `stockDATE` varchar(25) DEFAULT NULL,
  `stockInBy` varchar(60) DEFAULT NULL,
  `status` varchar(20) DEFAULT NULL,
  `vendor_id` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `stocks`
--

INSERT INTO `stocks` (`stock_id`, `referenceNo`, `products_id`, `stockDATE`, `stockInBy`, `status`, `vendor_id`) VALUES
(45, 213359853221, 'P-00602', '15/11/2022', 'admin', NULL, 1),
(46, 672463242561, 'P-00728', '15/11/2022', '50', 'Functioning', 2),
(47, 184558204912, 'P-00618', '17/11/2022', 'Ian ', NULL, 2);

-- --------------------------------------------------------

--
-- Table structure for table `stock_adjustment`
--

CREATE TABLE `stock_adjustment` (
  `stock_adjustment_id` int NOT NULL,
  `referenceNo` int DEFAULT NULL,
  `products_id` varchar(20) DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `action` varchar(50) DEFAULT NULL,
  `remarks` text,
  `users` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `stock_adjustment`
--

INSERT INTO `stock_adjustment` (`stock_adjustment_id`, `referenceNo`, `products_id`, `quantity`, `action`, `remarks`, `users`) VALUES
(34, 2182022, 'P-00602', 40, 'ADD TO INVENTORY', 'adding mo stocks', 'admin'),
(35, 9662022, 'P-00618', 50, 'ADD TO INVENTORY', 'adding new 50 stocks', 'admin'),
(36, 6632022, 'P-00618', 20, 'REMOVE FROM INVENTORY', 'removing from inventory', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `transaction`
--

CREATE TABLE `transaction` (
  `transaction_id` int NOT NULL,
  `transactionNo` varchar(15) DEFAULT NULL,
  `products_id` varchar(20) DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `discount_percent` decimal(18,2) DEFAULT NULL,
  `discount` decimal(18,2) DEFAULT NULL,
  `total` decimal(18,2) DEFAULT NULL,
  `cashier` varchar(30) DEFAULT NULL,
  `date_created` date DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `transaction`
--

INSERT INTO `transaction` (`transaction_id`, `transactionNo`, `products_id`, `quantity`, `discount_percent`, `discount`, `total`, `cashier`, `date_created`, `status`) VALUES
(15, '33339520221117', 'P-00728', 1, NULL, '0.00', '500.00', 'cashier', '2022-11-17', 'approve'),
(16, '73417720221117', 'P-00728', 1, '0.25', '125.00', '375.00', 'cashier', '2022-11-17', 'approve');

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
  `address` text,
  `age` int NOT NULL,
  `gender` varchar(7) NOT NULL,
  `usertype` varchar(20) DEFAULT NULL,
  `date_created` datetime DEFAULT NULL,
  `date_updated` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
  `vat_id` int NOT NULL,
  `vat` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
  `vendor_id` int NOT NULL,
  `vendor` varchar(100) DEFAULT NULL,
  `address` text,
  `contactPerson` varchar(50) DEFAULT NULL,
  `telephoneNo` varchar(13) DEFAULT NULL,
  `email` varchar(20) DEFAULT NULL,
  `fax` varchar(13) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

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
`action` varchar(5)
,`cancelBy` varchar(50)
,`cancelSales_id` int
,`date_cancel` varchar(25)
,`description` text
,`price` decimal(18,2)
,`products_id` varchar(20)
,`quantity` int
,`reason` text
,`total` decimal(28,2)
,`transaction_id` int
,`voidby` varchar(50)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `viewcriticalitems`
-- (See below for the actual view)
--
CREATE TABLE `viewcriticalitems` (
`barcode` varchar(15)
,`brand_name` varchar(50)
,`category_name` varchar(100)
,`description` text
,`price` decimal(18,2)
,`product_name` varchar(50)
,`products_id` varchar(20)
,`quantity` int
,`reorder` int
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `viewproductinventory`
-- (See below for the actual view)
--
CREATE TABLE `viewproductinventory` (
`barcode` varchar(15)
,`brand_name` varchar(50)
,`category_name` varchar(100)
,`description` text
,`price` decimal(18,2)
,`product_name` varchar(50)
,`products_id` varchar(20)
,`quantity` int
,`reorder` int
);

-- --------------------------------------------------------

--
-- Structure for view `viewcance_sales`
--
DROP TABLE IF EXISTS `viewcance_sales`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `viewcance_sales`  AS SELECT `c`.`cancelSales_id` AS `cancelSales_id`, `t`.`transaction_id` AS `transaction_id`, `t`.`products_id` AS `products_id`, `p`.`description` AS `description`, `p`.`price` AS `price`, `c`.`quantity` AS `quantity`, (`c`.`quantity` * `p`.`price`) AS `total`, `c`.`date_cancel` AS `date_cancel`, `c`.`voidby` AS `voidby`, `c`.`cancelBy` AS `cancelBy`, `c`.`reason` AS `reason`, `c`.`action` AS `action` FROM ((`cancel_sales` `c` join `product` `p` on((`p`.`products_id` = `c`.`products_id`))) join `transaction` `t` on((`t`.`transaction_id` = `c`.`transaction_id`)))  ;

-- --------------------------------------------------------

--
-- Structure for view `viewcriticalitems`
--
DROP TABLE IF EXISTS `viewcriticalitems`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `viewcriticalitems`  AS SELECT `p`.`products_id` AS `products_id`, `p`.`barcode` AS `barcode`, `p`.`product_name` AS `product_name`, `c`.`category_name` AS `category_name`, `b`.`brand_name` AS `brand_name`, `p`.`description` AS `description`, `p`.`price` AS `price`, `p`.`reorder` AS `reorder`, `p`.`quantity` AS `quantity` FROM ((`product` `p` join `category` `c` on((`c`.`category_id` = `p`.`category_id`))) join `brand` `b` on((`b`.`brand_id` = `p`.`brand_id`))) WHERE (`p`.`quantity` <= `p`.`reorder`)  ;

-- --------------------------------------------------------

--
-- Structure for view `viewproductinventory`
--
DROP TABLE IF EXISTS `viewproductinventory`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `viewproductinventory`  AS SELECT `p`.`products_id` AS `products_id`, `p`.`barcode` AS `barcode`, `p`.`product_name` AS `product_name`, `c`.`category_name` AS `category_name`, `b`.`brand_name` AS `brand_name`, `p`.`description` AS `description`, `p`.`price` AS `price`, `p`.`reorder` AS `reorder`, `p`.`quantity` AS `quantity` FROM ((`product` `p` join `category` `c` on((`c`.`category_id` = `p`.`category_id`))) join `brand` `b` on((`b`.`brand_id` = `p`.`brand_id`)))  ;

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
  MODIFY `brand_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT for table `cancel_sales`
--
ALTER TABLE `cancel_sales`
  MODIFY `cancelSales_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `category_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `stocks`
--
ALTER TABLE `stocks`
  MODIFY `stock_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=48;

--
-- AUTO_INCREMENT for table `stock_adjustment`
--
ALTER TABLE `stock_adjustment`
  MODIFY `stock_adjustment_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT for table `transaction`
--
ALTER TABLE `transaction`
  MODIFY `transaction_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `vatable`
--
ALTER TABLE `vatable`
  MODIFY `vat_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `vendor`
--
ALTER TABLE `vendor`
  MODIFY `vendor_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `product_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `category` (`category_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `product_ibfk_2` FOREIGN KEY (`brand_id`) REFERENCES `brand` (`brand_id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
