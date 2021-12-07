import { FormBuilder, FormGroup, Validators } from "@angular/forms";

import { FormModel } from "src/app/common/models/form.model";
import { IModel } from "src/app/common/models/model";
import { ValidatorWrapper } from "src/app/common/validators/validator-wrapper";

export class ChangePassword extends FormModel<ChangePassword> implements IModel<ChangePassword> {
    public currentPassword!: string;
    public password!: string;
    public confirmPassword!: string;

    public toForm(): FormGroup {
        return new FormBuilder().group({
            currentpassword: [this.currentPassword, [ValidatorWrapper.isValid(Validators.required, "Informe sua senha atual"),
                                       ValidatorWrapper.isValid(Validators.minLength(6), "A senha deve conter no minímo 6 e no máximo 15 caracteres"),
                                       ValidatorWrapper.isValid(Validators.maxLength(16), "A senha deve conter no minímo 6 e no máximo 15 caracteres")]],

            password: [this.password, [ValidatorWrapper.isValid(Validators.required, "Informe sua nova senha"),
                                       ValidatorWrapper.isValid(Validators.minLength(6), "A senha deve conter no minímo 6 e no máximo 15 caracteres"),
                                       ValidatorWrapper.isValid(Validators.maxLength(16), "A senha deve conter no minímo 6 e no máximo 15 caracteres")]],

            confirmpassword: [this.confirmPassword, [ValidatorWrapper.isValid(Validators.required, "Confirme sua nova senha"),
                                       ValidatorWrapper.isValid(Validators.minLength(6), "A senha deve conter no minímo 6 e no máximo 15 caracteres"),
                                       ValidatorWrapper.isValid(Validators.maxLength(16), "A senha deve conter no minímo 6 e no máximo 15 caracteres")]],
        });
    }

    public toModel(form: FormGroup): ChangePassword {
        let model = new ChangePassword();

        model.currentPassword =  form.controls.currentpassword ? form.controls.currentpassword.value : '';
        model.password =  form.controls.password ? form.controls.password.value : '';        
        model.confirmPassword =  form.controls.confirmpassword ? form.controls.confirmpassword.value : '';        

        return model;
    }

	public createNew(params: any): ChangePassword | undefined {
		if(!params)
			return undefined;

		let model = new ChangePassword();

		if(params) {
			model.currentPassword = params.currentPassword;
			model.password = params.password;
			model.confirmPassword = params.confirmPassword;	
		}

		return model;
	}
}