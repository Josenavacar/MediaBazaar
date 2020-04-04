<?php
	define("ROOT", dirname(__DIR__) . DIRECTORY_SEPARATOR);
	// get files
	require(ROOT . "core/config.php");
	require(ROOT . "core/route.php");
	require(ROOT . "core/core.php");

	// call route function
	route();