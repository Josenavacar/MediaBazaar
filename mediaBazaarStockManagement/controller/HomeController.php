<?php
	require(ROOT . "model/InventoryModel.php");
	require(ROOT . "model/OrderModel.php");
	require(ROOT . "model/CategoryModel.php");
	require(ROOT . "model/ProductModel.php");

	function index()
	{
		$units = getAllInventory();
		$orders = getAllOrders();
		$duplicateProducts = getOrdersWithMultipleOccuringProducts();
		$products = getAllProducts();
		$categories = getAllCategories();

		$bestSellingProducts = array();
		foreach ($duplicateProducts as $key => $value) 
		{
			$bestSellingProducts[] = $value;
		}

		$ordersPerMonth = array();
		foreach ($orders as $key => $value) 
		{
			$currentMonth = date('m');
			$orderMonth = date('m', strtotime($value['OrderDate']));

			if ($currentMonth == $orderMonth) 
			{
				$ordersPerMonth[] = $value['OrderDate'];
			}
		}

		$apiKey = "4add09fa6e8b2b38cd61a35795d144c9";
		$cityId = "2749990";
		$googleApiUrl = "http://api.openweathermap.org/data/2.5/weather?id=" . $cityId . "&lang=en&units=metric&APPID=" . $apiKey;

		$ch = curl_init();

		curl_setopt($ch, CURLOPT_HEADER, 0);
		curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
		curl_setopt($ch, CURLOPT_URL, $googleApiUrl);
		curl_setopt($ch, CURLOPT_FOLLOWLOCATION, 1);
		curl_setopt($ch, CURLOPT_VERBOSE, 0);
		curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);
		$response = curl_exec($ch);
		curl_close($ch);
		$data = json_decode($response);
		$currentTime = time();
		// var_dump($data);

		render("home/index", array
								(	
									'units' => $units, 
									'orders' => $orders, 
									'bestSellingProducts' => $bestSellingProducts, 
									'ordersPerMonth' => $ordersPerMonth, 
									'products' => $products, 
									'categories' => $categories,
									'data' => $data,
									'currentTime' => $currentTime
								));	
	}

	function getWeatherAPI()
	{
		$apiKey = "4add09fa6e8b2b38cd61a35795d144c9";
		$cityId = "2749990";
		$googleApiUrl = "http://api.openweathermap.org/data/2.5/weather?id=" . $cityId . "&lang=en&units=metric&APPID=" . $apiKey;

		$ch = curl_init();

		curl_setopt($ch, CURLOPT_HEADER, 0);
		curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
		curl_setopt($ch, CURLOPT_URL, $googleApiUrl);
		curl_setopt($ch, CURLOPT_FOLLOWLOCATION, 1);
		curl_setopt($ch, CURLOPT_VERBOSE, 0);
		curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);
		$response = curl_exec($ch);

		curl_close($ch);
		$data = json_decode($response);
		$currentTime = time();

		$d = array();
		$d = $data;
		// var_dump($d);
		// var_dump($data->main->temp);
	}
?>