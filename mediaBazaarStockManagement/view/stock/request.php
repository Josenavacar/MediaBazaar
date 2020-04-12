        <div class="container-fluid">
            <div class="request-form">
                <form action="<?= URL ?>stock/stockrequest" method="post">
                    <h2 class="text-center">Stock Request</h2>   
                    <div class="form-group">
                        <div class="input-group mb-3">
                            <input type="text" class="form-control">
                            <div class="dropdown">
                                <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    Quantity
                                </button>
                                <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                    <a class="dropdown-item" href="#">Action</a>
                                </div>
                            </div>
                        </div>
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">$</span>
                            </div>
                            <input type="text" class="form-control" aria-label="Amount (to the nearest dollar)">
                            <div class="input-group-append">
                                <span class="input-group-text">.00</span>
                            </div>
                        </div>
                        <div class="input-group mb-3">
                            <input type="text" class="form-control">                            
                        </div>
                    </div>       
                    <button type="submit" class="btn btn-primary btn-lg btn-block submit">Submit</button>
                </form>
            </div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
</div>