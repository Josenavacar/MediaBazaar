        <div class="container-fluid">
            <div class="request-form">
                <form action="<?= URL ?>stock/stockrequest" method="post">
                    <h2 class="text-center">Stock Request</h2>
                    <hr>   
                    <div class="form-group">
                        <div class="input-group">
                            <div class="col-lg-6 mb-3">
                                <div class="form-label-group">
                                    <input placeholder="Email" type="text" class="form-control">
                                    <label>Email</label>
                                </div>                                
                            </div>

                            <select class="form-control">
                                <option hidden >Department</option>
                                <option>Hardware</option>
                                <option>Marketing</option>
                            </select>
                        </div>

                        <div class="input-group">
                            <div class="col-lg-6 mb-3">
                                <div class="form-label-group">
                                    <input placeholder="Products" type="text" class="form-control">
                                    <label>Product</label>
                                </div>                                
                            </div>

                            <select class="form-control">
                                <option hidden >Quantity</option>
                                <option>100</option>
                                <option>200</option>
                                <option>300</option>
                                <option>400</option>
                                <option>500</option>
                            </select>
                        </div>

                        <div class="input-group">
                            <div class="col-lg-6 mb-3">
                                <div class="form-label-group">
                                    <input placeholder="Price" type="text" class="form-control">
                                    <label>Price</label>
                                </div>                                
                            </div>
                        </div>
                    </div>       
                    <button type="submit" class="btn btn-lg btn-outline-info btn-block submit">Submit</button>
                </form>
            </div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
</div>