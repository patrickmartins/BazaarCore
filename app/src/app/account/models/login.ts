import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { IModel } from "src/app/common/models/model";
import { ValidatorWrapper } from "src/app/common/validators/validator-wrapper";

import { FormModel } from "../../common/models/form.model";

export class LoginModel extends FormModel<LoginModel> implements IModel<LoginModel> {
    public email: string = '';
    public password: string = '';    

    public toForm(): FormGroup {
        return new FormBuilder().group({
            email: [this.email, [ValidatorWrapper.isValid(Validators.required, "Informe seu email"),
                                 ValidatorWrapper.isValid(Validators.pattern(/^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/), "O e-mail informado não é válido")]],

            password: [this.password, [ValidatorWrapper.isValid(Validators.required, "Informe sua senha"),
                                       ValidatorWrapper.isValid(Validators.minLength(5), "A senha deve conter no minímo 6 e no máximo 15 caracteres"),
                                       ValidatorWrapper.isValid(Validators.maxLength(15), "A senha deve conter no minímo 6 e no máximo 15 caracteres")]]
        });
    }

    public toModel(form: FormGroup): LoginModel {
        let model = new LoginModel();

        model.email =  form.controls.email ? form.controls.email.value : '';
        model.password =  form.controls.password ? form.controls.password.value : '';        

        return model;
    }

	public createNew(params: any): LoginModel | undefined {
		if(!params)
			return undefined;

		let model = new LoginModel();

		if(params) {
			model.email = params.email;
			model.password = params.password;
		}

		return model;
	}
}