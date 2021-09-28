import { Directive, Input } from '@angular/core';
import { FormGroupDirective } from '@angular/forms';

@Directive({
  selector: '[disableInputs]'
})

export class DisableInputsDirective {

    @Input()
    public set disableInputs(disable: boolean) {
        Object.keys(this.fb.form.controls).forEach(input => {
            disable ? this.fb.form.controls[input].disable() : this.fb.form.controls[input].enable();
        });        
    }

    constructor(private fb: FormGroupDirective) { }    

}