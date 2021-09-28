import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { FormModel } from "src/app/common/models/form.model";
import { ValidatorWrapper } from "src/app/common/validators/validator-wrapper";

export class RegisterModel extends FormModel<RegisterModel> {
    
    public name: string = "";
    public lastName: string = "";
    public email: string = "";
    public password: string = "";
    public confirmPassword: string = "";

    public toForm(): FormGroup {
        return new FormBuilder().group({
            name: [this.name, [ValidatorWrapper.isValid(Validators.required, "Informe seu nome"),
                               ValidatorWrapper.isValid(Validators.minLength(5), "O nome deve conter no mínimo 5 e no máximo 15 caracteres"),
                               ValidatorWrapper.isValid(Validators.maxLength(15), "O nome deve conter no mínimo 5 e no máximo 15 caracteres")]],

            lastname: [this.lastName, [ValidatorWrapper.isValid(Validators.required, "Informe seu sobrenome"),
                                       ValidatorWrapper.isValid(Validators.minLength(5), "O sobrenome deve conter no mínimo 5 e no máximo 30 caracteres"),
                                       ValidatorWrapper.isValid(Validators.maxLength(30), "O sobrenome deve conter no mínimo 5 e no máximo 30 caracteres")]],

            email: [this.email, [ValidatorWrapper.isValid(Validators.required, "Informe seu email"),
                                 ValidatorWrapper.isValid(Validators.pattern(/^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/), "O e-mail informado não é válido")]],

            password: [this.password, [ValidatorWrapper.isValid(Validators.required, "Informe sua senha"),
                                       ValidatorWrapper.isValid(Validators.minLength(6), "A senha deve conter no minímo 6 e no máximo 15 caracteres"),
                                       ValidatorWrapper.isValid(Validators.maxLength(16), "A senha deve conter no minímo 6 e no máximo 15 caracteres")]],

            confirmpassword: [this.confirmPassword, [ValidatorWrapper.isValid(Validators.required, "Informe sua senha"),
                                       ValidatorWrapper.isValid(Validators.minLength(6), "A senha deve conter no minímo 6 e no máximo 15 caracteres"),
                                       ValidatorWrapper.isValid(Validators.maxLength(16), "A senha deve conter no minímo 6 e no máximo 15 caracteres")]],
        });
    }

    public toModel(form: FormGroup): RegisterModel {
        let model = new RegisterModel();

        model.name =  form.controls.name ? form.controls.name.value : '';
        model.lastName =  form.controls.lastname ? form.controls.lastname.value : '';        
        model.email =  form.controls.email ? form.controls.email.value : '';        
        model.password =  form.controls.password ? form.controls.password.value : '';        
        model.confirmPassword =  form.controls.confirmpassword ? form.controls.confirmpassword.value : '';    

        return model;
    }
}