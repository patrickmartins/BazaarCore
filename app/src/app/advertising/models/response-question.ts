import { QuestionModel } from "./question";
import { ResponseModel } from "./response";

export class ResponseQuestionModel {
	public response!: ResponseModel;
	public question!: QuestionModel;
}