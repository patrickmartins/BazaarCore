import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { FormModel } from "src/app/common/models/form.model";
import { IModel } from "src/app/common/models/model";
import { ValidatorWrapper } from "src/app/common/validators/validator-wrapper";
import { Category } from "src/app/shared/models/category";

export class SearchAdModel extends FormModel<SearchAdModel> implements IModel<SearchAdModel>  {

	public categories!: string[];
	public maxPrice!: number;
	public minPrice!: number;
	public order!: number;
	public page!: number;
	public keywordSearch!: string;
	public pageSize!: number;

	constructor() {
		super();

		this.page = 1;
		this.pageSize = 9;
		this.minPrice = 0
		this.maxPrice = 2000;
		this.order = 2;
	}

	public toForm(): FormGroup {
		return new FormBuilder().group({
			categories: [this.categories],
			maxPrice: [this.maxPrice],
			minPrice: [this.minPrice],
			page: [this.page],
			order: [this.order, [ValidatorWrapper.isValid(Validators.minLength(2), "Ordem inválida"),
									ValidatorWrapper.isValid(Validators.maxLength(2), "Ordem inválida")]],
			
			pageSize: [this.pageSize,[ValidatorWrapper.isValid(Validators.required, "O tamanho da página deve ser no mínimo 5 e no máximo 50"),
										ValidatorWrapper.isValid(Validators.minLength(3), "O tamanho da página deve ser no mínimo 5 e no máximo 50"),
										ValidatorWrapper.isValid(Validators.maxLength(50), "O tamanho da página deve ser no mínimo 5 e no máximo 50")]],

            keywordSearch: [this.keywordSearch, [ValidatorWrapper.isValid(Validators.required, "O termo de pesquisa não pode ser vazio"),
                                       ValidatorWrapper.isValid(Validators.minLength(3), "O termo de pesquisa deve conter no minímo 3 e no máximo 20 caracteres"),
                                       ValidatorWrapper.isValid(Validators.maxLength(20), "O termo de pesquisa deve conter no minímo 3 e no máximo 20 caracteres")]]
        });
	}

	public toModel(form: FormGroup): SearchAdModel {
		let model = new SearchAdModel();

        model.keywordSearch =  form.controls.keywordSearch ? form.controls.keywordSearch.value : '';        
		model.categories = form.controls.categories ? form.controls.categories.value : [];
		model.maxPrice = form.controls.maxPrice ? form.controls.maxPrice.value : 0;
		model.minPrice = form.controls.minPrice ? form.controls.minPrice.value : 0;
		model.order = form.controls.order ? form.controls.order.value : 0;
		model.page = form.controls.page ? form.controls.page.value : 0;
		model.pageSize = form.controls.pageSize ? form.controls.pageSize.value : 10;

        return model;
	}

	public createNew(params: any): SearchAdModel | undefined {
		if(!params)
			return undefined;

		let search = new SearchAdModel();

		if(params) {
			if(params.maxPrice)
				search.maxPrice = Number(params.maxPrice);

			if(params.minPrice)
				search.minPrice = Number(params.minPrice);
			
			if(params.order)
				search.order = Number(params.order);
			
			if(params.page)
				search.page = Number(params.page);
			
			if(params.keywordSearch)
				search.keywordSearch = params.keywordSearch;
			
			if(params.pageSize)
				search.pageSize = Number(params.pageSize);
			
			search.categories = params.categories 
								? Array.isArray(params.categories) ? params.categories : [params.categories]
								: [];
		}

		return search;
	}	
}