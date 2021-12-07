import { FormGroup } from "@angular/forms";
import { filter } from "rxjs/operators";

import { Error } from "../models/error";
import { FormModel } from "../models/form.model";

export class BazaarForm<TModel extends FormModel<TModel>> {
    public formGroup!: FormGroup;
    public errors: { [source: string]: Error[] } = { };

    private model!: TModel;    
    private status: string = "INVALID";

    constructor(modelType: (new () => TModel)) {
		this.model = new modelType();
		this.formGroup = this.model.toForm();

		this.subscribeFormStatusChange(this.formGroup);	
    }

	public setModel(model: TModel) {
		this.model = model;
		this.formGroup = model.toForm();
		this.errors = this.getFormValidationErrors(this.formGroup);

		this.subscribeFormStatusChange(this.formGroup);		
	}

    public getModel(): TModel {
        return this.model.toModel(this.formGroup);
    }

    public clearValidationErrors(){
        this.errors = { };
    }

    public addValidationErrors(errors: Error[]) {
        errors.forEach(error => {
            this.addValidationError(error);
        });
    }

    public addValidationError(error: Error) {
        let key = error.source.toLowerCase();

        this.setFormValidationErrors(this.formGroup, [error]);

        if(this.errors[key]) {
            this.errors[key].push(error);
        }
        else {
            this.errors[key] = [error];
        }
    }

	public isValid(): boolean {
		return this.formGroup.valid;
	}

	private subscribeFormStatusChange(formGroup: FormGroup) {
		formGroup.statusChanges
			.pipe(filter((status) => !(this.formGroup.status == "VALID" && this.status == "VALID") && (status == "VALID" || status == "INVALID")))
			.subscribe(status => this.onStatusChanges(status));
	}

    private onStatusChanges(status: string) {                
        this.errors = this.getFormValidationErrors(this.formGroup);
        this.status = status;
    }

    private getFormValidationErrors(form: FormGroup): { [source: string]: Error[] } {
        let errors: { [source: string]: Error[] } = { };

        Object.keys(form.controls).forEach(input => {
            if(form.controls[input].errors) {
                let inputErrors = form.controls[input].errors;

                if(inputErrors) {
                    errors[input] = [];

                    Object.keys(inputErrors).forEach(id => {  
                        let error = new Error();

                        error.source = input;
                        error.description = inputErrors ? inputErrors[id].errorMessage : "";   
                        
                        errors[input].push(error);
                    });
                }                        
            }
        })

        return errors;
    }

    private setFormValidationErrors(form: FormGroup, errors: Error[]) {
        Object.keys(form.controls).forEach(input => {
            var inputErrors = errors.filter(c => c.source.toLowerCase() == input.toLowerCase());

            inputErrors.forEach(error => {  
                form.controls[input].setErrors({'app': error.description})
            });  
        });
    }
}