import { Component, OnDestroy } from '@angular/core';
import { MDBModalRef, MDBModalService } from 'angular-bootstrap-md';
import { ToastrService } from 'ngx-toastr';

import { Factory } from 'src/app/common/factories/factory';
import { FormBaseComponent } from 'src/app/common/form/form-base.component';
import { Error } from 'src/app/common/models/error';
import { ModalAvatarComponent } from '../modal-avatar/modal-avatar.component';
import { ChangePasswordModel } from '../models/change-password';
import { User } from '../models/user';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent extends FormBaseComponent<ChangePasswordModel> implements OnDestroy {

	private modalRef: MDBModalRef | undefined;
    
	public changingPassword: boolean = false;
	public loggedUser!: User | undefined;

    constructor(private accountService: AccountService, private toastr: ToastrService, private modalService: MDBModalService) {
        super(new Factory<ChangePasswordModel>(ChangePasswordModel));

		accountService
			.getLoggedUser()
			.subscribe((user: User | undefined) => { 
				this.loggedUser = user;
			});
    }

    public changePassword() {
        if(this.form.valid) {
            let model = this.getModel();
            
            this.changingPassword = true;

            this.accountService
                .changePassword(model)
                .subscribe(
                    () => this.toastr.success("Senha alterada com sucesso!"),
                    (errors: Error[]) => {
                        this.clearValidationErrors();
                        this.addValidationErrors(errors);
                    }
                )
                .add(() => this.changingPassword = false);
        }
    }

    public openAvatarProfile(event: any) {        
        this.modalRef = this.modalService.show(ModalAvatarComponent, { data: { imageChangeEvent: event }, class: 'modal-dialog-centered' });
    }

	public ngOnDestroy(): void {
		this.modalRef?.hide();
	}

}
