import { Component, OnDestroy } from '@angular/core';
import { MDBModalRef, MDBModalService } from 'angular-bootstrap-md';
import { ToastrService } from 'ngx-toastr';

import { BazaarForm } from 'src/app/common/form/form-base.component';
import { Error } from 'src/app/common/models/error';
import { ChangePassword } from '../../models/change-password';
import { User } from '../../models/user';
import { AccountService } from '../../../shared/services/account.service';
import { ModalAvatarComponent } from '../modal-avatar/modal-avatar.component';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnDestroy {

	private modalRef: MDBModalRef | undefined;
    
	public changingPassword: boolean = false;
	public loggedUser!: User | undefined;
	public changePasswordform: BazaarForm<ChangePassword>;

    constructor(private accountService: AccountService, private toastr: ToastrService, private modalService: MDBModalService) {
		this.changePasswordform = new BazaarForm<ChangePassword>(ChangePassword);
		
		accountService
			.getLoggedUser()
			.subscribe((user: User | undefined) => { 
				this.loggedUser = user;
			});
    }

    public changePassword() {
        if(this.changePasswordform.isValid()) {
            let model = this.changePasswordform.getModel();
            
            this.changingPassword = true;

            this.accountService
                .changePassword(model)
                .subscribe(
                    () => this.toastr.success("Senha alterada com sucesso!"),
                    (errors: Error[]) => {
                        this.changePasswordform.clearValidationErrors();
                        this.changePasswordform.addValidationErrors(errors);
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
