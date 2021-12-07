import { User } from "src/app/account/models/user";
import { IModel } from "src/app/common/models/model";
import { QuestionModel } from "./question";

export class AdDetailed implements IModel<AdDetailed> {
	public id!: string;
	public date!: number;
	public title!: string;
	public description!: string;
	public idCategory!: string;
	public price!: number;
	public pictures!: string[];
	public advertiser!: User;	

	private _questions!: QuestionModel[];

	public get questions(): QuestionModel[] {
		return this._questions.sort((q1, q2) => q1.date < q2.date ? 1 : -1);
	}

	public set questions(questions: QuestionModel[]) {
		this._questions = questions;
	}

	public addQuestion(question: QuestionModel) {
		this._questions.push(question);
	}

	constructor() {	}

	public createNew(params: any): AdDetailed | undefined {
		if(!params)
			return undefined;

		let ad = new AdDetailed();

		if(params) {
			ad.id = params.id;
			ad.date = params.date;
			ad.title = params.title;
			ad.description = params.description;
			ad.idCategory = params.idCategory;
			ad.price = params.price;
			ad.pictures = params.pictures;

			ad.advertiser = new User().createNew(params.advertiser)!;
			ad.questions = Array.isArray(params.questions) ? Array.from(params.questions).map(item => new QuestionModel().createNew(item)!) : [];			
		}

		return ad;
	}
}