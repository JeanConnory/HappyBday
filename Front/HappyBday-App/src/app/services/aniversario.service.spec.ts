/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AniversarioService } from './aniversario.service';

describe('Service: Aniversario', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AniversarioService]
    });
  });

  it('should ...', inject([AniversarioService], (service: AniversarioService) => {
    expect(service).toBeTruthy();
  }));
});
