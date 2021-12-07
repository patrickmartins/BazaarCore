import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { BazaarForm } from 'src/app/common/form/form-base.component';
import { Error } from 'src/app/common/models/error';
import { RegisterModel } from '../../models/register';
import { AccountService } from '../../../shared/services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent {

    public registering: boolean = false;
	public registerForm: BazaarForm<RegisterModel>;

    constructor(private accountService: AccountService, private router: Router) {
        this.registerForm = new BazaarForm<RegisterModel>(RegisterModel);
    }

    public register() {
        if(this.registerForm.isValid()) {
            let model = this.registerForm.getModel();
            
            this.registering = true;

            this.accountService
                .register(model)
                .subscribe(
                    () => this.router.navigate(["/account/login"]),
                    (errors: Error[]) => {
                        this.registerForm.clearValidationErrors();
                        this.registerForm.addValidationErrors(errors);
                        
                        this.registering = false;
                    }
                );
        }
    }
}
