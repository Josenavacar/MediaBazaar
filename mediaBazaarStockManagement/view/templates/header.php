<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">

  <title>Stock Management</title>
  <!-- Bootstrap core CSS -->
  <link href="bootstrap/css/bootstrap.min.css" type="text/css" rel="stylesheet">
  <!-- Custom styles for this template -->
  <link href="css/media_bazaar_css.css" type="text/css" rel="stylesheet">
  <link rel="stylesheet" type="text/css" href="css/floating_css.css">
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>

<body>
	<div class="d-flex" id="wrapper">
    <!-- Sidebar -->
    <div class="bg-light border-right" id="sidebar-wrapper">
        <div class="sidebar-heading">
            <h2>Media Bazaar</h2> 
            <h6>a Jupyter company</h6>
        </div>
        <div class="list-group list-group-flush">
            <a href="home" class="list-group-item list-group-item-action bg-light">Inventory</a>
            <a href="order" class="list-group-item list-group-item-action bg-light">Orders</a>
            <a href="login" class="loginbutton list-group-item list-group-item-action bg-light">Login</a>
            <a href="product" class="list-group-item list-group-item-action bg-light">Products</a>
            <a href="category" class="list-group-item list-group-item-action bg-light">Categories</a>
            <a href="stock" class="list-group-item list-group-item-action bg-light">Stock Request</a>
            <a href="login/logout" class="list-group-item list-group-item-action bg-light">Logout</a>
        </div>
    </div>
    <!-- /#sidebar-wrapper -->

    <!-- Page Content -->
    <div id="page-content-wrapper">
        <nav class="navbar navbar-expand-lg navbar-light bg-light border-bottom">
            <button class="btn btn-outline-primary" id="menu-toggle">Toggle Menu</button>
            <button class="btn btn-outline-dark" id="backButton">Back</button>

            <div class="custom-control custom-switch">
                <input type="checkbox" class="custom-control-input" id="customSwitch1" data-toggle="toggle">
                <label class="custom-control-label" for="customSwitch1">Dark mode</label>
            </div>
            
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
              <span class="navbar-toggler-icon"></span>
            </button>
        </nav>
