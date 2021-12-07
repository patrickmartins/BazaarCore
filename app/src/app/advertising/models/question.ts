import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { User } from "src/app/account/models/user";
import { FormModel } from "src/app/common/models/form.model";
import { IModel } from "src/app/common/models/model";
import { ValidatorWrapper } from "src/app/common/validators/validator-wrapper";
import { ResponseModel } from "./response";

export class QuestionModel extends FormModel<QuestionModel> implements IModel<QuestionModel> {

	public id!: string;
	public description!: string;
	public date!: string;
	public user!: User;
	public response!: ResponseModel;

	public createNew(params: any): QuestionModel | undefined {
		if(!params)
			return undefined;

		let question = new QuestionModel();

		if(params) {
			question.id = params.id;
			question.date = params.date;
			question.description = params.description;

			question.user = new User().createNew(params.user)!;
			question.response = new ResponseModel().createNew(params.response)!;					
		}

		return question;
	}

	public toForm(): FormGroup {
		return new FormBuilder().group({
            description: [this.description, [ValidatorWrapper.isValid(Validators.required, "A pergunta não pode ser vazia"),
                                       ValidatorWrapper.isValid(Validators.minLength(5), "A pergunta deve conter no minímo 5 e no máximo 2000 caracteres"),
                                       ValidatorWrapper.isValid(Validators.maxLength(2000), "A pergunta deve conter no minímo 5 e no máximo 2000 caracteres")]]
        });
	}

	public toModel(form: FormGroup): QuestionModel {
		let model = new QuestionModel();

        model.description =  form.controls.description ? form.controls.description.value : '';        

        return model;
	}
}