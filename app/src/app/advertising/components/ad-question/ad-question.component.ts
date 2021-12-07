import { Component, EventEmitter, Input, Output } from '@angular/core';
import { User } from 'src/app/account/models/user';
import { BazaarForm } from 'src/app/common/form/form-base.component';
import { QuestionModel } from '../../models/question';
import { ResponseModel } from '../../models/response';
import { ResponseQuestionModel } from '../../models/response-question';

@Component({
  selector: 'ad-question',
  templateUrl: './ad-question.component.html',
  styleUrls: ['./ad-question.component.css']
})
export class AdQuestionComponent {

	public formResponse!: BazaarForm<ResponseModel>;
	public answering: boolean = false;
	public formOpened: boolean = false;

	@Input()
	public question!: QuestionModel;

	@Input()
	public advertiser!: User;

	@Input()
	public canAnswer!: boolean;

	@Output()
	public onAnswer = new EventEmitter<ResponseQuestionModel>();

  	constructor() {
		this.formResponse = new BazaarForm<ResponseModel>(ResponseModel);
	}

	public openFormAnswer() {
		this.formOpened = true;
	}

	public answer() {
		let data = new ResponseQuestionModel();

		data.response = this.formResponse.getModel();
		data.question = this.question;

		this.answering = true;
		
		this.onAnswer.emit(data);
	}
}
