import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { User } from 'src/app/account/models/user';
import { BazaarForm } from 'src/app/common/form/form-base.component';
import { AccountService } from 'src/app/shared/services/account.service';
import { AdvertisingService } from 'src/app/shared/services/advertising.service';
import { AdDetailed } from '../../models/ad-detailed';
import { QuestionModel } from '../../models/question';
import { ResponseQuestionModel } from '../../models/response-question';

@Component({
  selector: 'ad',
  templateUrl: './ad.component.html',
  styleUrls: ['./ad.component.css']
})
export class AdComponent implements OnInit {

	public ad!: AdDetailed;
	public loggedUser: User | undefined;
	public formQuestion: BazaarForm<QuestionModel>;
	public loadingAd: boolean = true;
	public asking: boolean = false;

	constructor(private accountService: AccountService, private advertisingService: AdvertisingService, private activeRoute: ActivatedRoute, private router: Router) {
		this.formQuestion = new BazaarForm<QuestionModel>(QuestionModel);

		this.accountService
				.getLoggedUser()
				.subscribe((user: User | undefined) => {
					this.loggedUser = user;
				});
	}

	public ngOnInit(): void {
		let idAd = this.activeRoute.snapshot.paramMap.get("id");
		
		this.loadingAd = true;

		if(idAd) {
			this.advertisingService
					.getById(idAd)
					.subscribe((ad: AdDetailed) => this.ad = ad)					
					.add(() => this.loadingAd = false);
		} else {
			this.router.navigate(["home"]);
		}
	}

	public ask() {
		let question = this.formQuestion.getModel();

		this.asking = true;

		this.advertisingService
				.ask(this.ad.id, question)
				.subscribe(() => {					
					this.accountService.getLoggedUser().subscribe((user: User | undefined) => question.user = user!);
					
					this.formQuestion.formGroup.reset();
					question.date = new Date().toISOString();
					
					this.ad.addQuestion(question);
				})
				.add(() => this.asking = false);
	}

	public onAnswer(data: ResponseQuestionModel) {
		let response = data.response;
		let question = data.question;

		this.advertisingService
				.answer(this.ad.id, question.id, response)
				.subscribe(() => {
					this.accountService.getLoggedUser().subscribe((user: User | undefined) => response.user = user!);

					question.response = question;
				});
	}

	public trackByDate(index: number, question: QuestionModel) {
		return question.date;
	}
}