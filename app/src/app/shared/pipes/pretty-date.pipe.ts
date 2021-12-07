import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'prettyDate'
})
export class PrettyDatePipe implements PipeTransform {

  	transform(value: string, ...args: string[]): string {
		let date = new Date(value);
		let format = args.length > 0 ? args[0] : "short";

		if (format === "elapsed") {
			let diff = (((new Date()).getTime() - date.getTime()) / 1000);
			let	day_diff = Math.floor(diff / 86400);

			if (isNaN(day_diff) || day_diff < 0)
				return "";

			if(day_diff === 0) {
				if(diff < 60) return "Agora mesmo";
				else if(diff < 120) return "1 minuto atrás";
				else if(diff < 3600) return Math.floor(diff / 60) + " minutos atrás";
				else if(diff < 7200) return "1 hora atrás";
				else if(diff < 86400) return (Math.floor(diff / 3600) + " horas atrás");
			} else {
				if(day_diff === 1) return "Ontem";
				else if(day_diff < 7) return day_diff + " dias atrás";
				else if(day_diff < 31) return Math.floor(day_diff / 7) + " semanas atrás";
				else if(day_diff < 63) return "1 mês atrás";
				else if(day_diff > 31 && day_diff < 360) return (Math.floor(day_diff / 30) + " meses atrás");
				else if(day_diff < 430) return "1 ano atrás";
				else if(day_diff > 365) return (Math.floor(day_diff / 365) + " anos atrás");
			}

		} else if (format === "short") {
			return ("0" + date.getDate()).slice(-2) + "/" + ("0" + (date.getMonth() + 1)).slice(-2) + "/" + ("0" + date.getFullYear()).slice(-2);

		} else if (format === "full") {
			let days = ["Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"];
			let months = ["janeiro", "fevereiro", "março", "abril", "maio", "junho", "julho", "agosto", "setembro", "outubro", "novembro", "dezembro"];

			return days[date.getDay()] + ", " +
				date.getDate() + " de " +
				months[date.getMonth()] + " de " +
				date.getFullYear() + " às " +
				("0" + date.getHours()).slice(-2) + ":" + ("0" + date.getMinutes()).slice(-2);
		}

		return "";
  }
}
