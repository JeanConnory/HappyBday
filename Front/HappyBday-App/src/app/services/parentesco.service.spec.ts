/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ParentescoService } from './parentesco.service';

describe('Service: Parentesco', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ParentescoService]
    });
  });

  it('should ...', inject([ParentescoService], (service: ParentescoService) => {
    expect(service).toBeTruthy();
  }));
});
