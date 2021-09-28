import { FormGroup } from "@angular/forms";
import { filter } from "rxjs/operators";

import { Factory } from "../factories/factory";
import { Error } from "../models/error";
import { FormModel } from "../models/form.model";

export abstract class FormBaseComponent<TModel extends FormModel<TModel>> {
    public form: FormGroup;
    public errors: { [source: string]: Error[] } = { };

    private model: TModel;    
    private status: string = "INVALID";

    constructor(private factory: Factory<TModel>) {
        this.model = this.factory.create();
        this.form = this.model.toForm();        

        this.form.statusChanges
                 .pipe(filter((status) => !(this.form.status == "VALID" && this.status == "VALID") && (status == "VALID" || status == "INVALID")))
                 .subscribe(status => this.onStatusChanges(status));
    }

    protected getModel(): TModel {
        return this.model.toModel(this.form);
    }

    protected clearValidationErrors(){
        this.errors = { };
    }

    protected addValidationErrors(errors: Error[]) {
        errors.forEach(error => {
            this.addValidationError(error);
        });
    }

    protected addValidationError(error: Error) {
        let key = error.source.toLowerCase();

        this.setFormValidationErrors(this.form, [error]);

        if(this.errors[key]) {
            this.errors[key].push(error);
        }
        else {
            this.errors[key] = [error];
        }
    }

    private onStatusChanges(status: string) {                
        this.errors = this.getFormValidationErrors(this.form);
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