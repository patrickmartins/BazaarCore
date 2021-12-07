import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { User } from "src/app/account/models/user";
import { FormModel } from "src/app/common/models/form.model";
import { IModel } from "src/app/common/models/model";
import { ValidatorWrapper } from "src/app/common/validators/validator-wrapper";

export class ResponseModel extends FormModel<ResponseModel> implements IModel<ResponseModel> {
	public description!: string;
	public date!: string;
	public user!: User;

	public createNew(params: any): ResponseModel | undefined {
		if(!params)
			return undefined;

		let response = new ResponseModel();

		if(params) {
			response.date = params.date;
			response.description = params.description;			
		}

		return response;
	}

	public toForm(): FormGroup {
		return new FormBuilder().group({
            description: [this.description, [ValidatorWrapper.isValid(Validators.required, "A resposta não pode ser vazia"),
                                       ValidatorWrapper.isValid(Validators.minLength(5), "A resposta deve conter no minímo 5 e no máximo 2000 caracteres"),
                                       ValidatorWrapper.isValid(Validators.maxLength(2000), "A resposta deve conter no minímo 5 e no máximo 2000 caracteres")]]
        });
	}

	public toModel(form: FormGroup): ResponseModel {
		let model = new ResponseModel();

        model.description =  form.controls.description ? form.controls.description.value : '';        

        return model;
	}
}