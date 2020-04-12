        <div class="container-fluid">
            <div class="login-form">
                <form action="<?= URL ?>login/login" method="post">
                    <div class="avatar">
                        <img src="images/project_logo.png" alt="">
                    </div>
                    <h2 class="text-center">Login</h2>   
                    <div class="form-label-group">
                        <input type="text" class="form-control" name="passcode" placeholder="Passcode" required="required">
                        <label>Passcode</label>
                    </div>       
                    <div class="form-group">
                        <button type="submit" class="btn btn-primary btn-lg btn-block">Sign in</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
</div>