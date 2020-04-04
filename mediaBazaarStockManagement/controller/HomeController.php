<?php
	require(ROOT . "model/InventoryModel.php");

	function index()
	{
		$units = getAllInventory();

		render("home/index", array('units' => $units));	
	}
?>