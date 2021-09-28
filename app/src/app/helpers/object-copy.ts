export function copy(target: any, ...sources: any[]): any {
	if (!sources.length) return target;

	const source = sources.shift();

	if (isObject(target) && isObject(source)) {
		for (const key in source) {
			if (isObject(source[key])) {
				Object.assign(target[key], source[key]);
			} else {
				target[key] = source[key];				
			}
		}
	}

	return copy(target, ...sources);
}

export function isObject(item: any) {
	return item && typeof item === "object" && !Array.isArray(item);
}